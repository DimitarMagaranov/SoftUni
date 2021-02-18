using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<int> claimedItems = new List<int>();

            Queue<int> firstLoopBoxToQueue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Stack<int> secondLoopBoxToStack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            while (firstLoopBoxToQueue.Any() && secondLoopBoxToStack.Any())
            {
                int reusltOfSum = firstLoopBoxToQueue.Peek() + secondLoopBoxToStack.Peek();

                if (reusltOfSum % 2 == 0)
                {
                    claimedItems.Add(reusltOfSum);
                    firstLoopBoxToQueue.Dequeue();
                    secondLoopBoxToStack.Pop();
                }
                else
                {
                    int lastItemOfSecondBox = secondLoopBoxToStack.Pop();
                    firstLoopBoxToQueue.Enqueue(lastItemOfSecondBox);
                }

                if (firstLoopBoxToQueue.Any() == false)
                {
                    Console.WriteLine("First lootbox is empty");
                }
                else if (secondLoopBoxToStack.Any() == false)
                {
                    Console.WriteLine("Second lootbox is empty");
                }
            }

            int sumClaimedItems = 0;

            foreach (var item in claimedItems)
            {
                sumClaimedItems += item;
            }

            if (sumClaimedItems >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {sumClaimedItems}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {sumClaimedItems}");
            }
        }
    }
}
