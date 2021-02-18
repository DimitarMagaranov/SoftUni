using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sequence = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < sequence.Length; i++)
            {
                stack.Push(sequence[i]);
            }

            int capacityOfRack = int.Parse(Console.ReadLine());

            int valueSum = 0;

            int countOfRacks = 1;

            while (true)
            {
                if (stack.Any() == false)
                {
                    break;
                }

                int currentValue = stack.Peek();
                int checkedSum = valueSum + currentValue;

                if (checkedSum <= capacityOfRack)
                {
                    valueSum += currentValue;
                    stack.Pop();
                }
                else
                {
                    valueSum = 0;
                    countOfRacks += 1;
                }
            }

            Console.WriteLine(countOfRacks);
        }
    }
}
