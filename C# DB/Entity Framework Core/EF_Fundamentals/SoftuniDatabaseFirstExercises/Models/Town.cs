using System;
using System.Collections.Generic;

namespace SoftuniDatabaseFirstExercises.Models
{
    public partial class Town
    {
        public Town()
        {
            Addresses = new HashSet<Addresse>();
        }

        public int TownId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Addresse> Addresses { get; set; }
    }
}
