namespace P04_BorderControl
{
    using P04_BorderControl.Interfaces;
    using P04_BorderControl.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            Dictionary<string, IBuyer> members = new Dictionary<string, IBuyer>();

            int linesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < linesCount; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 4)
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string id = tokens[2];
                    string birthdate = tokens[3];

                    IBuyer citizen = new Citizen(name, age, id, birthdate);

                    if (members.ContainsKey(name) == false)
                    {
                        members.Add(name, new Citizen(name, age, id, birthdate));
                    }
                }
                else if (tokens.Length == 3)
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string group = tokens[2];

                    IBuyer rebel = new Rebel(name, age, group);

                    if (members.ContainsKey(name) == false)
                    {
                        members.Add(name, new Rebel(name, age, group));
                    }
                }
            }

            while (true)
            {
                string name = Console.ReadLine();

                if (name == "End")
                {
                    break;
                }

                if (members.ContainsKey(name))
                {
                    members[name].BuyFood();
                }
            }

            Console.WriteLine(members.Values.Sum(x => x.Food));
        }
    }
}
