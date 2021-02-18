using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace P06_ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Reverse()
                .ToList();

            int devisibleNumber = int.Parse(Console.ReadLine());

            Predicate<double> isInteger = x => x == (int)x;
            //Func<double, bool> isInteger = x => x == (int)x;

            for (int i = 0; i < numbers.Count; i++)
            {
                double result = (double)numbers[i] / devisibleNumber;

                if (isInteger(result))
                {
                    numbers.Remove(numbers[i]);
                    i--;
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
