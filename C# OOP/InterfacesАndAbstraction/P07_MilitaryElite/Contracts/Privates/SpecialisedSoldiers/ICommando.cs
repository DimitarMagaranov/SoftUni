using P07_MilitaryElite.Models.Privates.SpecialisedSoldiers;
using System.Collections.Generic;

namespace P07_MilitaryElite.Contracts.Privates.SpecialisedSoldiers
{
    public interface ICommando
    {
        IReadOnlyCollection<Mission> Missions { get; }

        void CompleteMission(string codeName);
    }
}
