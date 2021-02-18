using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> family = new List<Person>();

        public void AddMember(Person member)
        {
            this.family.Add(member);
        }

        public Person GetOldestMember()
        {
            return this.family.OrderByDescending(x => x.Age).FirstOrDefault();
        }

        public List<Person> GetPeopleOverThirty()
        {
            List<Person> peopleOverThirty = this.family.Where(x => x.Age > 30).OrderBy(y => y.Name).ToList();

            return peopleOverThirty;
        }
    }
}
