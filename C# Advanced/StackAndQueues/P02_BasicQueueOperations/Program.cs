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

            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < inputLine.Count; i++)
            {
                queue.Enqueue(inputLine[i]);
            }

            for (int i = 0; i < numberOfElementsToPop; i++)
            {
                queue.Dequeue();
            }

            if (queue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                if (queue.Contains(theElementWichINeed))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(queue.Min());
                }
            }
        }
    }
}
