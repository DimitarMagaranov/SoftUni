using System;
using System.Collections.Generic;

namespace P01_Vehicles.Models
{
    public static class VehiclesFactory
    {
        public static List<Vehicle> GetVehicles()
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            for (int i = 0; i < 3; i++)
            {
                string[] vehicleArgs = Console.ReadLine().Split();

                double fuelQuantity = double.Parse(vehicleArgs[1]);
                double literConsumptiontPerKm = double.Parse(vehicleArgs[2]);
                int tankCapacity = int.Parse(vehicleArgs[3]);

                switch (i)
                {
                    case 0: Car car = new Car(fuelQuantity, literConsumptiontPerKm, tankCapacity); vehicles.Add(car); break;
                    case 1: Truck truck = new Truck(fuelQuantity, literConsumptiontPerKm, tankCapacity); vehicles.Add(truck); break;
                    case 2: Bus bus = new Bus(fuelQuantity, literConsumptiontPerKm, tankCapacity); vehicles.Add(bus); break;
                    default:
                        break;
                }
            }

            return vehicles;
        }
    }
}
