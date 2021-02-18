namespace SantaWorkshop.Core
{
    using SantaWorkshop.Core.Contracts;
    using SantaWorkshop.Models.Dwarfs;
    using SantaWorkshop.Models.Dwarfs.Contracts;
    using SantaWorkshop.Models.Instruments;
    using SantaWorkshop.Models.Instruments.Contracts;
    using SantaWorkshop.Models.Presents;
    using SantaWorkshop.Models.Presents.Contracts;
    using SantaWorkshop.Models.Workshops;
    using SantaWorkshop.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private const int DwarfMinCraftEnergy = 50;

        private DwarfRepository dwarfs;
        private PresentRepository presents;
        private int craftedPresentsCount = 0;

        public Controller()
        {
            this.dwarfs = new DwarfRepository();
            this.presents = new PresentRepository();
        }

        public string AddDwarf(string dwarfType, string dwarfName)
        {
            IDwarf dwarf = null;

            if (dwarfType == "HappyDwarf")
            {
                dwarf = new HappyDwarf(dwarfName);
            }
            else if (dwarfType == "SleepyDwarf")
            {
                dwarf = new SleepyDwarf(dwarfName);
            }

            if (dwarf == null)
            {
                throw new InvalidOperationException("Invalid dwarf type.");
            }

            this.dwarfs.Add(dwarf);

            return $"Successfully added {dwarfType} named {dwarfName}.";
        }

        public string AddInstrumentToDwarf(string dwarfName, int power)
        {
            IDwarf dwarf = this.dwarfs.FindByName(dwarfName);

            if (dwarf == null)
            {
                throw new InvalidOperationException("The dwarf you want to add an instrument to doesn't exist!");
            }

            IInstrument instrument = new Instrument(power);

            dwarf.AddInstrument(instrument);

            return $"Successfully added instrument with power {power} to dwarf {dwarfName}!";
        }

        public string AddPresent(string presentName, int energyRequired)
        {
            IPresent present = new Present(presentName, energyRequired);

            this.presents.Add(present);

            return $"Successfully added Present: {presentName}!";
        }

        public string CraftPresent(string presentName)
        {
            Workshop workshop = new Workshop();

            IPresent present = this.presents.FindByName(presentName);

            ICollection<IDwarf> craftDwarfs = this.dwarfs.Models
                .Where(x => x.Energy >= DwarfMinCraftEnergy)
                .OrderByDescending(x => x.Energy)
                .ToList();

            if (craftDwarfs.Any() == false)
            {
                throw new InvalidOperationException("There is no dwarf ready to start crafting!");
            }

            while (craftDwarfs.Any())
            {
                IDwarf currDwarf = craftDwarfs.First();

                workshop.Craft(present, currDwarf);

                if (currDwarf.Instruments.Any() == false)
                {
                    craftDwarfs.Remove(currDwarf);
                }

                if (currDwarf.Energy == 0)
                {
                    craftDwarfs.Remove(currDwarf);
                    this.dwarfs.Remove(currDwarf);
                }

                if (present.IsDone())
                {
                    break;
                }
            }

            string output = present.IsDone() == true ? $"Present {presentName} is done." : $"Present {presentName} is not done.";

            return output;
            //if (present.IsDone() == false)
            //{
            //    return $"Present {presentName} is not done.";
            //}
            //else
            //{
            //    return $"Present {presentName} is done.";
            //}
        }

        public string Report()
        {
            int countCraftedPresents = this.presents.Models.Count(x => x.IsDone() == true);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{countCraftedPresents} presents are done!");

            sb.AppendLine("Dwarfs info:");

            foreach (IDwarf dwarf in this.dwarfs.Models)
            {
                int countInstruments = dwarf.Instruments.Count(x => x.IsBroken() == false);

                sb.AppendLine($"Name: {dwarf.Name}");
                sb.AppendLine($"Energy: {dwarf.Energy}");
                sb.AppendLine($"Instruments {countInstruments} not broken left");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
