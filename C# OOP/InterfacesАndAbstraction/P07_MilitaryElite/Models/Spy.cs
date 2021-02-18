using P07_MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P07_MilitaryElite.Models
{
    public class Spy : Soldier, ISpy
    {
        public Spy(string id, string firstName, string lastName, int codeNumber)
            : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get; private set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(base.ToString());
            stringBuilder.Append($"Code Number: {this.CodeNumber}");

            return stringBuilder.ToString();
        }
    }
}
