namespace P04_PizzaCalories.Models
{
    using System;
    using System.Collections.Generic;
    using P04_PizzaCalories.Models.Ingredients;

    public class Pizza
    {
        private string name;
        private List<Topping> toppings;
        private Dough dough;

        public Pizza(string name)
        {
            this.Name = name;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (value == string.Empty || value.Length > 15)
                {
                    throw new InvalidProgramException(Exeptions.InvalidPizzaNameException);
                }

                this.name = value;
            }
        }

        public int CountOfToppings => this.toppings.Count;

        public void AddTopping(Topping topping)
        {
            if (toppings.Count == 10)
            {
                throw new InvalidProgramException(Exeptions.InvalidToppingCountException);
            }

            toppings.Add(topping);
        }

        public void AddDough(Dough dough)
        {
            this.dough = dough;
        }

        public double TotalCalories()
        {
            double calories = 0;

            foreach (var topping in this.toppings)
            {
                calories += topping.CalculateCalories();
            }

            calories += this.dough.CalculateCalories();

            return calories;
        }
    }
}
