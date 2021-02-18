using P07_MilitaryElite.Models;
using System.Collections.Generic;

namespace P07_MilitaryElite.Contracts.Privates
{
    public interface ILieutenantGeneral
    {
        IReadOnlyCollection<Private> Privates { get; }
    }
}
