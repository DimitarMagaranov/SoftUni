using System;
using System.Collections.Generic;
using System.Text;

namespace P07_MilitaryElite.Models
{
    public class Private : Soldier
    {
        public Private(string id, string firstName, string lastName, decimal salary)
        : base(id, firstName, lastName)
        {
            this.Salary = salary;
        }

        public decimal Salary { get; private set; }

        public override string ToString()
        {
            return $"{base.ToString()} Salary: {this.Salary:F2}";
        }
    }
}
