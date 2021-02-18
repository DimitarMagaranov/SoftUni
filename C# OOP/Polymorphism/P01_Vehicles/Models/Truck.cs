namespace P01_Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double airConditionConsumption = 1.6;
        private const double wastedFuelPercent = 0.05;

        public Truck(double fuelQuantity, double fuelConsumption, int tankCapacity)
            : base(fuelQuantity, fuelConsumption + airConditionConsumption, tankCapacity)
        {
        }

        public override void Refuel(double amount)
        {
            base.Refuel(amount);

            this.FuelQuantity -= amount * wastedFuelPercent;
        }
    }
}
