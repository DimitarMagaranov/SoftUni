using P07_MilitaryElite.Contracts.Privates.SpecialisedSoldiers;
using System;
using System.Collections.Generic;
using System.Text;

namespace P07_MilitaryElite.Models.Privates.SpecialisedSoldiers
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(string id, string firstName, string lastName, decimal salary, string corps, List<Repair> repairs)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Repairs = repairs;
        }

        public IReadOnlyCollection<Repair> Repairs { get; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(base.ToString());
            stringBuilder.AppendLine("Repairs:");

            foreach (var repair in this.Repairs)
            {
                stringBuilder.AppendLine("  " + repair.ToString());
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
