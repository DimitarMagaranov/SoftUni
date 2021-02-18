using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.roster = new List<Player>();
        }

        public string Name { get; private set; }

        public int Capacity { get; private set; }

        public int Count => this.roster.Count();

        public void AddPlayer(Player player)
        {
            if (this.roster.Any(x => x.Name == player.Name) == false && this.Count < this.Capacity)
            {
                this.roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            Player player = this.roster.FirstOrDefault(x => x.Name == name);

            if (player != null)
            {
                this.roster.Remove(player);

                return true;
            }

            return false;
        }

        public void PromotePlayer(string name)
        {
            Player player = this.roster.FirstOrDefault(x => x.Name == name);

            if (player != null && player.Rank != "Member")
            {
                player.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            Player player = this.roster.FirstOrDefault(x => x.Name == name);

            if (player != null && player.Rank != "Trial")
            {
                player.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string @class)
        {
            List<Player> kickedPlayers = this.roster.Where(x => x.Class == @class).ToList();

            this.roster = this.roster.Where(x => x.Class != @class).ToList();

            return kickedPlayers.ToArray();
        }

        public string Report()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Players in the guild: {this.Name}");

            if (this.Count != 0)
            {
                foreach (var player in this.roster)
                {
                    stringBuilder.AppendLine(player.ToString());
                }
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
