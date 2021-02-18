using System;
using System.Collections.Generic;
using System.Text;

namespace SantaWorkshop.Models.Dwarfs
{
    public class HappyDwarf : Dwarf
    {
        private const int HappyDwarfEnergy = 100;
        private const int WorkEnergyDecrement = 5;

        public HappyDwarf(string name)
            : base(name, HappyDwarfEnergy)
        {
        }

        public override void Work()
        {
            base.Work();
            this.Energy -= WorkEnergyDecrement;
        }
    }
}
