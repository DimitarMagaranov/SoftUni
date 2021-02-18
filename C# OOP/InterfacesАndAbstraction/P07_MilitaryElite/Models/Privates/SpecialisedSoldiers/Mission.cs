using P07_MilitaryElite.Contracts.Privates.SpecialisedSoldiers;
using System;
using System.Collections.Generic;
using System.Text;

namespace P07_MilitaryElite.Models.Privates.SpecialisedSoldiers
{
    public class Mission : IMission
    {
        private string state;

        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = state;
        }

        public string CodeName { get; private set; }

        public string State
        {
            get => this.state;
            set
            {
                if (value != "inProgress" && value != "Finished")
                {
                    throw new ArgumentException("Invalid state!");
                }

                this.state = value;
            }
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}
