using System;
using System.Collections.Generic;
using System.Text;

namespace P07_MilitaryElite.Contracts.Privates.SpecialisedSoldiers
{
    public interface IMission
    {
        string CodeName { get; }
        string State { get; }
    }
}
