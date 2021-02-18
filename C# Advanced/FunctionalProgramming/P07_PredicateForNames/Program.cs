using System;
using System.Collections.Generic;
using System.Linq;

namespace P07_PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfLetters = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine()
                .Split()
                .ToList();

            List<string> endNames = new List<string>();

            Predicate<string> predicateName = x => x.Length <= countOfLetters;

            Action<List<string>> print = x => Console.WriteLine(string.Join(Environment.NewLine, x));

            foreach (var name in names)
            {
                if (predicateName(name))
                {
                    endNames.Add(name);
                }
            }

            print(endNames);
        }
    }
}
