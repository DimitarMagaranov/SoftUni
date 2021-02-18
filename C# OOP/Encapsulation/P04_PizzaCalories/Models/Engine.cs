namespace P04_PizzaCalories.Models
{
    using System;
    using P04_PizzaCalories.Models.Ingredients;

    public class Engine
    {
        public void Run()
        {
            try
            {
                string[] pizzaArguments = Console.ReadLine().Split();

                string nameOfPizza = pizzaArguments[1];

                Pizza pizza = new Pizza(nameOfPizza);

                while (true)
                {
                    string[] inputLine = Console.ReadLine().Split();

                    if (inputLine[0] == "END")
                    {
                        break;
                    }

                    if (inputLine[0] == "Dough")
                    {
                        string flourType = inputLine[1];
                        string bakingTechnique = inputLine[2];
                        double doughWeight = double.Parse(inputLine[3]);

                        Dough dough = new Dough(flourType, bakingTechnique, doughWeight);

                        pizza.AddDough(dough);
                    }
                    else if (inputLine[0] == "Topping")
                    {
                        string toppingType = inputLine[1];
                        double toppingWeight = double.Parse(inputLine[2]);

                        Topping topping = new Topping(toppingType, toppingWeight);

                        pizza.AddTopping(topping);
                    }
                }

                double totalCalories = pizza.TotalCalories();

                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories():f2} Calories.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
    }
}
