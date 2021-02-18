using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_FindEvenOrOdd
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine();

            Predicate<int> filter = x => command == "odd" ? x % 2 != 0 : x % 2 == 0;

            List<int> numbers = new List<int>();

            for (int i = input[0]; i <= input[1]; i++)
            {
                numbers.Add(i);
            }

            Action<List<int>> print = x => Console.WriteLine(string.Join(" ",numbers.Where( y => filter(y))));

            print(numbers);
        }
    }
}
