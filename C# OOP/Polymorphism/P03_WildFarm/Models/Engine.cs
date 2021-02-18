using P03_WildFarm.Models.Animals;
using P03_WildFarm.Models.Foods;
using System;
using System.Collections.Generic;

namespace P03_WildFarm.Models
{
    public class Engine
    {
        public void Run()
        {
            List<Animal> animals = new List<Animal>();

            while (true)
            {
                string inputLine = Console.ReadLine();

                if (inputLine == "End")
                {
                    break;
                }

                string[] animalArgs = inputLine.Split();

                Animal animal = AnimalFactory.Create(animalArgs);

                animal.ProduceSoundForFood();

                string[] foodArgs = Console.ReadLine().Split();

                Food food = FoodFactory.Create(foodArgs);

                ConsolePrinter.Print(animal.ProduceSoundForFood());

                try
                {
                    animal.Eat(food);
                }
                catch (Exception ex)
                {
                    ConsolePrinter.Print(ex.Message);
                }

                animals.Add(animal);
            }

            foreach (var animal in animals)
            {
                ConsolePrinter.Print(animal.ToString());
            }
        }
    }
}
