using System;
using System.Collections.Generic;
using System.Linq;

namespace P03_CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> integers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            Func<List<int>, int> findMinNumber = x => x.Min();

            Console.WriteLine(findMinNumber(integers));
        }
    }
}
