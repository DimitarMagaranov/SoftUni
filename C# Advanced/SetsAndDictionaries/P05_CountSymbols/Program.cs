using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();

            Dictionary<char, int> dictionary = new Dictionary<char, int>();

            foreach (var charr in input)
            {
                if (dictionary.ContainsKey(charr) == false)
                {
                    dictionary.Add(charr, 1);
                }
                else
                {
                    dictionary[charr]++;
                }
            }

            foreach (var item in dictionary.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
