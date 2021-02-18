using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> tokens = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int numberOfElementsToPush = tokens[0];
            int numberOfElementsToPop = tokens[1];
            int theElementWichINeed = tokens[2];

            List<int> inputLine = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < inputLine.Count; i++)
            {
                stack.Push(inputLine[i]);
            }

            for (int i = 0; i < numberOfElementsToPop; i++)
            {
                stack.Pop();
            }

            if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                if (stack.Contains(theElementWichINeed))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(stack.Min());
                }
            }
        }
    }
}
