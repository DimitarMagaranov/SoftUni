using System;
using System.Collections.Generic;
using System.Text;

namespace P07_MilitaryElite.Contracts.Privates.SpecialisedSoldiers
{
    public interface IRepair
    {
        string PartName { get; }
        int HoursWorked { get; }
    }
}
