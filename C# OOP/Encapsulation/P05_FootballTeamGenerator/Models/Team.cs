using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_FootballTeamGenerator.Models
{
    public class Team
    {
        private string name;
        private List<Player> team;

        public Team(string name)
        {
            this.Name = name;
            this.team = new List<Player>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                {
                    throw new InvalidOperationException("A name should not be empty.");
                }

                this.name = value;
            }
        }

        public void AddPlayer(Player player)
        {
            this.team.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            Player player = team.FirstOrDefault(x => x.Name == playerName);

            if (this.team.Contains(player) == false)
            {
                throw new InvalidOperationException($"Player {playerName} is not in {this.name} team.");
            }

            this.team.Remove(player);
        }

        public double ShowRating()
        {
            if (this.team.Any() == false)
            {
                throw new Exception($"{this.name} - 0");
            }
            List<double> playersRatings = new List<double>();

            foreach (var player in this.team)
            {
                playersRatings.Add(player.SkillLevel());
            }

            double result = playersRatings.Average();

            return Math.Round(result);
        }
    }
}
