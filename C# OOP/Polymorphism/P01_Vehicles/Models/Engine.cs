using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_Vehicles.Models
{
    public class Engine
    {
        public void Run()
        {
            List<Vehicle> vehicles = VehiclesFactory.GetVehicles();

            int linesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < linesCount; i++)
            {
                string[] commandArgs = Console.ReadLine().Split();

                string command = commandArgs[0];
                string vehicleType = commandArgs[1];

                Vehicle vehicle = vehicles.FirstOrDefault(x => x.GetType().Name == vehicleType);

                if (command == "Drive")
                {
                    double distance = double.Parse(commandArgs[2]);

                    Console.WriteLine(vehicle.Drive(distance));
                }
                else if (command == "DriveEmpty")
                {
                    double distance = double.Parse(commandArgs[2]);

                    Console.WriteLine(((Bus)vehicle).DriveEmpty(distance));
                }
                else
                {
                    try
                    {
                        double amount = double.Parse(commandArgs[2]);

                        vehicle.Refuel(amount);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
        }
    }
}
