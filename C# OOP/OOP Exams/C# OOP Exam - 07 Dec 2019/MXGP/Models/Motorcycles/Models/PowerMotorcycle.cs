namespace MXGP.Models.Motorcycles.Models
{
    using MXGP.Utilities.Messages;
    using System;

    public class PowerMotorcycle : Motorcycle
    {
        private const int MinHorsePower = 70;
        private const int MaxHorsePower = 100;
        private const double CurrentCubicCentimeters = 450;

        private int horsePower;

        public PowerMotorcycle(string model, int horsePower)
            : base(model, horsePower, CurrentCubicCentimeters)
        {
        }

        public override int HorsePower
        {
            get => this.horsePower;
            protected set
            {
                if (value < MinHorsePower || value > MaxHorsePower)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }

                this.horsePower = value;
            }
        }
    }
}
