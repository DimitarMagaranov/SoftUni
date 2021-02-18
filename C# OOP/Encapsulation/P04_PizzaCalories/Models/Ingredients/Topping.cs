namespace P04_PizzaCalories.Models.Ingredients
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Topping
    {
        private string type;
        private double weight;
        private string[] types = new string[] { "meat", "veggies", "cheese", "sauce" };

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public string Type
        {
            get => this.type;
            private set
            {
                string type = value.ToLower();

                if (IsInvalidType(type))
                {
                    throw new InvalidProgramException(String.Format(Exeptions.InvalidToppingTypeException, value));
                }

                this.type = value;
            }
        }

        public double Weight
        {
            get => this.weight;
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new InvalidProgramException(String.Format(Exeptions.InvalidToppingWeightException, value));
                }

                this.weight = value;
            }
        }

        public double CalculateCalories()
        {
            double calories = this.weight * 2;

            switch (this.type.ToLower())
            {
                case "meat":
                    calories *= 1.2;
                    break;
                case "veggies":
                    calories *= 0.8;
                    break;
                case "cheese":
                    calories *= 1.1;
                    break;
                case "sauce":
                    calories *= 0.9;
                    break;
                default:
                    break;
            }

            return calories;
        }

        private bool IsInvalidType(string type)
        {
            List<string> types = this.types.ToList();

            if (types.Contains(type))
            {
                return false;
            }

            return true;
        }
    }
}
