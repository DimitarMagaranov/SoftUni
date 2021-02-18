using System;
using System.Collections.Generic;
using System.Linq;

namespace P08_CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .OrderBy(x => x)
                .ToList();

            List<int> orderedList = new List<int>();

            Func<int, bool> oddFunction = x => x % 2 == 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                if (oddFunction(numbers[i]))
                {
                    orderedList.Add(numbers[i]);
                    numbers.Remove(numbers[i]);
                }
            }

            orderedList.AddRange(numbers);

            Console.WriteLine(string.Join(" ", orderedList));
        }
    }
}
