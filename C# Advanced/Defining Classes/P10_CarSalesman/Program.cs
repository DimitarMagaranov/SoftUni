using System;
using System.Collections.Generic;

namespace P10_CarSalesman
{
    public class Program
    {
        public static void Main()
        {
            List<Engine> engines = GetEngines();
            List<Car> cars = GetCars(engines);
            PrintCars(cars);
        }

        private static List<Engine> GetEngines()
        {
            int countOfEngines = int.Parse(Console.ReadLine());

            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < countOfEngines; i++)
            {
                string[] engineTokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = engineTokens[0];
                int power = int.Parse(engineTokens[1]);

                if (engineTokens.Length == 4)
                {
                    int displacement = int.Parse(engineTokens[2]);
                    string efficiency = engineTokens[3];

                    Engine engine = new Engine(model, power, displacement, efficiency);

                    engines.Add(engine);
                }
                else if (engineTokens.Length == 3)
                {
                    bool tryParser = int.TryParse(engineTokens[2], out _);

                    if (tryParser)
                    {
                        int displacement = int.Parse(engineTokens[2]);

                        Engine engine = new Engine(model, power, displacement);

                        engines.Add(engine);
                    }
                    else
                    {
                        string efficiency = engineTokens[2];

                        Engine engine = new Engine(model, power, efficiency);

                        engines.Add(engine);
                    }
                }
                else if (engineTokens.Length == 2)
                {
                    Engine engine = new Engine(model, power);

                    engines.Add(engine);
                }
            }

            return engines;
        }

        private static List<Car> GetCars(List<Engine> engines)
        {
            int countOfCars = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < countOfCars; i++)
            {
                string[] carTokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carTokens[0];
                string engineModelToString = carTokens[1];
                Engine engine = engines.Find(x => x.Model == engineModelToString);

                if (carTokens.Length == 4)
                {
                    int weight = int.Parse(carTokens[2]);
                    string color = carTokens[3];

                    Car car = new Car(model, engine, weight, color);

                    cars.Add(car);
                }
                else if (carTokens.Length == 3)
                {
                    bool tryParser = int.TryParse(carTokens[2], out _);

                    if (tryParser)
                    {
                        int weight = int.Parse(carTokens[2]);

                        Car car = new Car(model, engine, weight);

                        cars.Add(car);
                    }
                    else
                    {
                        string color = carTokens[2];

                        Car car = new Car(model, engine, color);

                        cars.Add(car);
                    }
                }
                else if (carTokens.Length == 2)
                {
                    Car car = new Car(model, engine);

                    cars.Add(car);
                }
            }

            return cars;
        }

        private static void PrintCars(List<Car> cars)
        {
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
