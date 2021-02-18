using System;
using System.Collections.Generic;

namespace P07_SpeedRacing
{
    public class Program
    {
        public static void Main()
        {
            List<Car> cars = GetCars();
            DriveCars(cars);
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
                double fuelAmount = double.Parse(carTokens[1]);
                double fuelConsumptionPerKM = double.Parse(carTokens[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionPerKM);

                cars.Add(car);
            }

            return cars;
        }

        private static void DriveCars(List<Car> cars)
        {
            while (true)
            {
                string[] driveTokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (driveTokens[0] == "End")
                {
                    break;
                }

                string model = driveTokens[1];
                int distance = int.Parse(driveTokens[2]);

                foreach (var car in cars)
                {
                    if (car.Model == model)
                    {
                        car.Drive(distance);
                    }
                }
            }
        }

        private static void Print(List<Car> cars)
        {
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.DistanceTraveled}");
            }
        }
    }
}
