using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            int countOfPeopleToAdd = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < countOfPeopleToAdd; i++)
            {
                string[] personToAdd = Console.ReadLine().Split();

                string name = personToAdd[0];
                int age = int.Parse(personToAdd[1]);

                Person person = new Person(name, age);

                family.AddMember(person);
            }

            List<Person> peopleOverThirty = family.GetPeopleOverThirty();

            Console.WriteLine(string.Join(Environment.NewLine, peopleOverThirty));
        }
    }
}
