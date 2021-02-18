using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.ReadLine()
            //    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            //    .Select(x => $"Sir {x}")
            //    .ToList()
            //    .ForEach(Console.WriteLine);


            List<string> names = Console.ReadLine()
                .Split()
                .ToList();

            Func<string, string> format = x => $"Sir {x}";

            Action<List<string>> print = x => Console.WriteLine(string.Join(Environment.NewLine, x.Select(format)));

            print(names);
        }
    }
}
