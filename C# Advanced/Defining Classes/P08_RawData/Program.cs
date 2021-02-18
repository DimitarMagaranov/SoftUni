using System;
using System.Collections.Generic;
using System.Linq;

namespace P08_RawData
{
    public class Program
    {
        public static void Main()
        {
            List<Car> cars = GetCars();
            Print(cars);
        }

        private static List<Car> GetCars()
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carTokens = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carTokens[0];
                int engineSpeed = int.Parse(carTokens[1]);
                int enginePower = int.Parse(carTokens[2]);
                int cargoWeight = int.Parse(carTokens[3]);
                string cargoType = carTokens[4];
                double tyre1Pressure = double.Parse(carTokens[5]);
                int tyre1Age = int.Parse(carTokens[6]);
                double tyre2Pressure = double.Parse(carTokens[7]);
                int tyre2Age = int.Parse(carTokens[8]);
                double tyre3Pressure = double.Parse(carTokens[9]);
                int tyre3Age = int.Parse(carTokens[10]);
                double tyre4Pressure = double.Parse(carTokens[11]);
                int tyre4Age = int.Parse(carTokens[12]);

                Tyre[] tyres = new Tyre[4];

                tyres[0] = new Tyre(tyre1Pressure, tyre1Age);
                tyres[1] = new Tyre(tyre2Pressure, tyre2Age);
                tyres[2] = new Tyre(tyre3Pressure, tyre3Age);
                tyres[3] = new Tyre(tyre4Pressure, tyre4Age);

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);

                Car car = new Car(model, engine, cargo, tyres);

                cars.Add(car);
            }

            return cars;
        }

        private static void Print(List<Car> cars)
        {
            string command = Console.ReadLine();

            switch (command)
            {
                case "fragile":
                    foreach (var car in cars.Where(c => c.Cargo.CargoType == command).Where(c => c.Tyres.Any(t => t.Presure < 1)))
                    {
                        Console.WriteLine(car.Model);
                    }
                    break;
                case "flamable":
                    foreach (var car in cars.Where(c => c.Cargo.CargoType == command).Where(c => c.Engine.EnginePower > 250))
                    {
                        Console.WriteLine(car.Model);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
