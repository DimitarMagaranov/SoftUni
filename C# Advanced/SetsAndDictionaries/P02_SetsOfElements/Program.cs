using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int sizeOfFirstSet = sizes[0];
            int sizeOfSecondSet = sizes[1];

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            for (int i = 0; i < sizeOfFirstSet; i++)
            {
                int number = int.Parse(Console.ReadLine());
                firstSet.Add(number);
            }

            for (int i = 0; i < sizeOfSecondSet; i++)
            {
                int number = int.Parse(Console.ReadLine());
                secondSet.Add(number);
            }

            HashSet<int> finishedSet = new HashSet<int>();

            foreach (var item in firstSet)
            {
                if (secondSet.Contains(item))
                {
                    finishedSet.Add(item);
                }
            }

            Console.WriteLine(string.Join(' ', finishedSet));
        }
    }
}
