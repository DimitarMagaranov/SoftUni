using SantaWorkshop.Models.Instruments.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SantaWorkshop.Models.Instruments
{
    public class Instrument : IInstrument
    {
        private const int UsePowerDecrement = 10;

        private int power;

        public Instrument(int power)
        {
            this.Power = power;
        }

        public int Power
        {
            get => this.power;
            private set
            {
                if (value < 0)
                {
                    this.power = 0;
                }

                this.power = value;
            }
        }

        public void Use()
        {
            this.Power -= UsePowerDecrement;
        }

        public bool IsBroken() => this.power == 0 ? true : false;
    }
}
