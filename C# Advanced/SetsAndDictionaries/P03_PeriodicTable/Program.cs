using System;
using System.Collections.Generic;
using System.Linq;

namespace P03_PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> set = new HashSet<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] elements = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                foreach (var item in elements)
                {
                    set.Add(item);
                }
            }

            foreach (var item in set.OrderBy(x => x))
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
