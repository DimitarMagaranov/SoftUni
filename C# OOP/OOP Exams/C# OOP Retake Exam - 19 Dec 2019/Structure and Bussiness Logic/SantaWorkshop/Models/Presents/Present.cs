namespace SantaWorkshop.Models.Presents
{
    using SantaWorkshop.Models.Presents.Contracts;
    using System;

    public class Present : IPresent
    {
        private const int CraftEnergyDecrement = 10;

        private string name;
        private int energyRequired;

        public Present(string name, int energyRequired)
        {
            this.Name = name;
            this.EnergyRequired = energyRequired;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Present name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public int EnergyRequired
        {
            get => this.energyRequired;
            private set
            {
                if (value < 0)
                {
                    this.energyRequired = 0;
                }

                this.energyRequired = value;
            }
        }

        public void GetCrafted()
        {
            this.EnergyRequired -= CraftEnergyDecrement;
        }

        public bool IsDone() => this.energyRequired == 0 ? true : false;
    }
}
