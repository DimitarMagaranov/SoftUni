using System;
using System.Collections.Generic;
using System.Text;

namespace P07_SpeedRacing
{
    public class Car
    {
        public Car(string model, double fuelAmount, double fuelComsumptionFor1Kilometer)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelComsumptionFor1Kilometer = fuelComsumptionFor1Kilometer;
            this.DistanceTraveled = 0;
        }

        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelComsumptionFor1Kilometer { get; set; }

        public int DistanceTraveled { get; set; }


        public void Drive(int distance)
        {
            double neededFuel = distance * this.FuelComsumptionFor1Kilometer;

            if (neededFuel > this.FuelAmount)
            {
                Console.WriteLine("Insufficient fuel for the drive");
                return;
            }

            this.FuelAmount -= neededFuel;
            this.DistanceTraveled += distance;
        }


    }
}
