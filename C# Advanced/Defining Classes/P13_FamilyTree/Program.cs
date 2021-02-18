using System;
using System.Collections.Generic;
using System.Linq;

namespace P13_FamilyTree
{
    public class Program
    {
        public static void Main()
        {
            string dateOrName = Console.ReadLine();

            List<Connection> connections = new List<Connection>();
            List<Person> peopleInfo = new List<Person>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                if (input.Contains(" - "))
                {
                    string[] splitedInput = input.Split(" - ");

                    string parentArgument = splitedInput[0];
                    string childArgument = splitedInput[1];

                    Person parent = new Person(parentArgument);
                    Person child = new Person(childArgument);

                    Connection connection = new Connection(parent, child);
                    connections.Add(connection);
                }
                else
                {
                    string[] splitedInput = input.Split();

                    string firstName = splitedInput[0];
                    string lastName = splitedInput[1];
                    string name = firstName + " " + lastName;
                    string birthDate = splitedInput[2];

                    Person person = new Person(name, birthDate);
                    peopleInfo.Add(person);
                }
            }

            Person mainPerson = peopleInfo
                .FirstOrDefault(x => x.Birthdate == dateOrName || x.Name == dateOrName);

            List<Connection> filterConnections = connections
                .Where(x => x.Parent.Birthdate == mainPerson.Birthdate
                || x.Child.Birthdate == mainPerson.Birthdate
                || x.Parent.Name == mainPerson.Name
                || x.Child.Name == mainPerson.Name)
                .ToList();

            Result result = new Result();

            result.MainPerson = mainPerson;

            foreach (var connection in filterConnections)
            {
                bool isChildByDate = connection.Child.Birthdate == mainPerson.Birthdate;
                bool isChildByName = connection.Child.Name == mainPerson.Name;

                bool isParentByDate = connection.Parent.Birthdate == mainPerson.Birthdate;
                bool isParentByName = connection.Parent.Name == mainPerson.Name;

                if (isChildByDate || isChildByName)
                {
                    Person parent = peopleInfo
                        .FirstOrDefault(x => x.Name == connection.Parent.Name
                        || x.Birthdate == connection.Parent.Birthdate);

                    result.Parents.Add(parent);
                }
                else if (isParentByDate || isParentByName)
                {
                    Person child = peopleInfo
                        .FirstOrDefault(x => x.Name == connection.Child.Name
                        || x.Birthdate == connection.Child.Birthdate);

                    result.Children.Add(child);
                }
            }

            Console.WriteLine(result);
        }
    }
}
