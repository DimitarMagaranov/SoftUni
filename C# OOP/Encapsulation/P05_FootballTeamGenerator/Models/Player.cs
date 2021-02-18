namespace P05_FootballTeamGenerator.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
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

        public int Endurance
        {
            get => this.endurance;
            private set
            {
                if (IsInvalidValue(value))
                {
                    throw new InvalidOperationException("Endurance should be between 0 and 100.");
                }

                this.endurance = value;
            }
        }

        public int Sprint
        {
            get => this.sprint;
            private set
            {
                if (IsInvalidValue(value))
                {
                    throw new InvalidOperationException("Sprint should be between 0 and 100.");
                }

                this.sprint = value;
            }
        }

        public int Dribble
        {
            get => this.dribble;
            private set
            {
                if (IsInvalidValue(value))
                {
                    throw new InvalidOperationException("Dribble should be between 0 and 100.");
                }

                this.dribble = value;
            }
        }

        public int Passing
        {
            get => this.passing;
            private set
            {
                if (IsInvalidValue(value))
                {
                    throw new InvalidOperationException("Passing should be between 0 and 100.");
                }

                this.passing = value;
            }
        }

        public int Shooting
        {
            get => this.shooting;
            private set
            {
                if (IsInvalidValue(value))
                {
                    throw new InvalidOperationException("Shooting should be between 0 and 100.");
                }

                this.shooting = value;
            }
        }

        public double SkillLevel()
        {
            List<int> stats = new List<int>();

            stats.Add(this.endurance);
            stats.Add(this.sprint);
            stats.Add(this.dribble);
            stats.Add(this.passing);
            stats.Add(this.shooting);
            
            return stats.Average();
        }

        private bool IsInvalidValue(int value)
        {
            if (value < 0 || value > 100)
            {
                return true;
            }

            return false;
        }
    }
}
