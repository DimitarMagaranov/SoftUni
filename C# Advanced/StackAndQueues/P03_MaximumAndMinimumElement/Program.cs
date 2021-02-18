using System;
using System.Collections.Generic;
using System.Linq;

namespace P03_MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            int numberOfInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfInputs; i++)
            {
                int[] tokens = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                if (tokens.Length > 1)
                {
                    stack.Push(tokens[1]);
                }
                else
                {
                    if (stack.Any())
                    {
                        if (tokens[0] == 2)
                        {
                            stack.Pop();
                        }
                        else if (tokens[0] == 3)
                        {
                            Console.WriteLine(stack.Max());
                        }
                        else if (tokens[0] == 4)
                        {
                            Console.WriteLine(stack.Min());
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(", ",stack));
        }
    }
}
