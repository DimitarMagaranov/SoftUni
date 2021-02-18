using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            Func<List<int>, List<int>> addFunction = x => x.Select(y => y += 1).ToList();
            Func<List<int>, List<int>> multiplyFunction = x => x.Select(y => y *= 2).ToList();
            Func<List<int>, List<int>> subtractFunction = x => x.Select(y => y -= 1).ToList();

            Action<List<int>> print = x => Console.WriteLine(string.Join(" ", x));

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                if (command == "add")
                {
                    numbers = addFunction(numbers);
                }
                else if (command == "multiply")
                {
                    numbers = multiplyFunction(numbers);
                }
                else if (command == "subtract")
                {
                    numbers = subtractFunction(numbers);
                }
                else
                {
                    print(numbers);
                }
            }
        }
    }
}
