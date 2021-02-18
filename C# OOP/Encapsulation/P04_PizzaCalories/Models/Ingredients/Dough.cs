namespace P04_PizzaCalories.Models.Ingredients
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double weight;
        private string[] modifiers = new string[] { "crispy", "chewy", "homemade" };
        private string[] doughTypes = new string[] { "White", "Wholegrain" };

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get => this.flourType;
            private set
            {
                string flourhType = value;

                if (IsInvalidDoughType(flourhType))
                {
                    throw new InvalidOperationException(Exeptions.InvalidDoughTypeException);
                }

                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get => this.bakingTechnique;
            set
            {
                string modifier = value.ToLower();

                if (IsInvalidModifier(modifier))
                {
                    throw new InvalidProgramException(Exeptions.InvalidDoughTypeException);
                }

                this.bakingTechnique = value;
            }
        }

        public double Weight
        {
            get => this.weight;
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new InvalidProgramException(Exeptions.InvalidDoughWeightException);
                }
                this.weight = value;
            }
        }

        public double CalculateCalories()
        {
            double calories = this.weight * 2;

            string bakingTechniqueToLower = this.bakingTechnique.ToLower();

            switch (this.flourType)
            {
                case "White":

                    calories *= 1.5;

                    if (bakingTechniqueToLower == "crispy")
                    {
                        calories *= 0.9;
                    }
                    else if (bakingTechniqueToLower == "chewy")
                    {
                        calories *= 1.1;
                    }
                    else if (bakingTechniqueToLower == "homemade")
                    {
                        calories *= 1.0;
                    }
                    break;
                case "Wholegrain":
                    if (bakingTechniqueToLower == "crispy")
                    {
                        calories *= 0.9;
                    }
                    else if (bakingTechniqueToLower == "chewy")
                    {
                        calories *= 1.1;
                    }
                    else if (bakingTechniqueToLower == "homemade")
                    {
                        calories *= 1.0;
                    }
                    break;
                default:
                    break;
            }

            return calories;
        }

        private bool IsInvalidModifier(string modifier)
        {
            List<string> modifiers = this.modifiers.ToList();

            if (modifiers.Contains(modifier))
            {
                return false;
            }

            return true;
        }

        private bool IsInvalidDoughType(string doughType)
        {
            List<string> doughTypes = this.doughTypes.ToList();

            if (doughTypes.Contains(doughType))
            {
                return false;
            }

            return true;
        }
    }
}
