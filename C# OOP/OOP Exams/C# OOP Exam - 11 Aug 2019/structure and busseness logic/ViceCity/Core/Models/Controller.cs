using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Core.Contracts;
using ViceCity.Models.Players.Contracts;
using ViceCity.Models.Players.Models;
using ViceCity.Repositories.Models;
using System.Reflection;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods.Models;

namespace ViceCity.Core.Models
{
    public class Controller : IController
    {
        private IPlayer mainPlayer;
        private List<IPlayer> civilPlayers;
        private GunRepository gunRepository;
        private GangNeighbourhood gangNeighbourhood;

        public Controller()
        {
            this.mainPlayer = new MainPlayer();
            this.civilPlayers = new List<IPlayer>();
            this.gunRepository = new GunRepository();
            this.gangNeighbourhood = new GangNeighbourhood();
        }

        public string AddGun(string type, string name)
        {
            var gunType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == type);

            if (gunType == null)
            {
                return "Invalid gun type!";
            }
            else
            {
                IGun gun = (IGun)Activator.CreateInstance(gunType, name);
                this.gunRepository.Add(gun);

                return $"Successfully added {name} of type: {type}";
            }
        }

        public string AddGunToPlayer(string name)
        {
            if (name == "Vercetti")
            {
                IGun gun = this.gunRepository.Models.FirstOrDefault();

                if (gun != null)
                {
                    this.mainPlayer.GunRepository.Add(gun);
                    this.gunRepository.Remove(gun);

                    return $"Successfully added {gun.Name} to the Main Player: Tommy Vercetti";
                }
                else
                {
                    return "There are no guns in the queue!";
                }
            }

            IPlayer civilPlayer = this.civilPlayers.FirstOrDefault(x => x.Name == name);

            if (civilPlayer != null)
            {
                IGun gun = this.gunRepository.Models.FirstOrDefault();

                if (gun != null)
                {
                    civilPlayer.GunRepository.Add(gun);
                    this.gunRepository.Remove(gun);

                    return $"Successfully added {gun.Name} to the Civil Player: {civilPlayer.Name}";
                }
                else
                {
                    return "There are no guns in the queue!";
                }
            }
            else
            {
                return "Civil player with that name doesn't exists!";
            }
        }

        public string AddPlayer(string name)
        {
            IPlayer civilPlayer = new CivilPlayer(name);
            this.civilPlayers.Add(civilPlayer);
            return $"Successfully added civil player: {name}!";
        }

        public string Fight()
        {
            int mainPlayerAllLifePoints = this.mainPlayer.LifePoints;
            int civilPlayersAllLifePoints = this.civilPlayers.Sum(x => x.LifePoints);

            this.gangNeighbourhood.Action(this.mainPlayer, this.civilPlayers);

            int mainPlayerCurrAllLifePoints = this.mainPlayer.LifePoints;
            int civilPlayersCurrAllLifePoints = this.civilPlayers.Sum(x => x.LifePoints);

            if (mainPlayerCurrAllLifePoints == mainPlayerAllLifePoints &&
                civilPlayersCurrAllLifePoints == civilPlayersAllLifePoints)
            {
                return "Everything is okay!";
            }
            else if (civilPlayersCurrAllLifePoints != civilPlayersAllLifePoints)
            {
                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.AppendLine("A fight happened:");
                stringBuilder.AppendLine($"Tommy live points: {mainPlayerCurrAllLifePoints}!");

                List<IPlayer> killedCivilPlayers = this.civilPlayers.Where(x => x.IsAlive == false).ToList();

                foreach (var civilPlayer in killedCivilPlayers)
                {
                    this.civilPlayers.Remove(civilPlayer);
                }

                stringBuilder.AppendLine($"Tommy has killed: {killedCivilPlayers.Count} players!");

                stringBuilder.AppendLine($"Left Civil Players: {this.civilPlayers.Count}!");

                return stringBuilder.ToString().TrimEnd();
            }
            else
            {
                return null;
            }
        }
    }
}
