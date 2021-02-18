using System.Collections.Generic;
using System.Linq;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Models.Neghbourhoods.Models
{
    public class GangNeighbourhood : INeighbourhood
    {
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            while (true)
            {
                IGun gun = mainPlayer.GunRepository.Models.FirstOrDefault(x => x.CanFire == true);

                if (gun == null)
                {
                    break;
                }

                IPlayer civil = civilPlayers.FirstOrDefault(x => x.IsAlive == true);

                if (civil == null)
                {
                    break;
                }

                int damagePoints = gun.Fire();
                civil.TakeLifePoints(damagePoints);
            }

            while (true)
            {
                IPlayer player = civilPlayers.FirstOrDefault(t => t.IsAlive == true);

                if (player == null)
                {
                    break;
                }

                IGun gun = player.GunRepository.Models.FirstOrDefault(g => g.CanFire == true);

                if (gun == null)
                {
                    break;
                }

                int damagePoints = gun.Fire();
                mainPlayer.TakeLifePoints(damagePoints);

                if (mainPlayer.IsAlive == false)
                {
                    break;
                }
            }
        }
    }
}
