﻿namespace P01_Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double airConditionConsumption = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, int tankCapacity)
            : base(fuelQuantity, fuelConsumption + airConditionConsumption, tankCapacity)
        {
        }
    }
}
