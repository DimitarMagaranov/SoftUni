using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantityOfTheFood = int.Parse(Console.ReadLine());

            int[] quantities = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> queueOfOrders = new Queue<int>();

            for (int i = 0; i < quantities.Length; i++)
            {
                queueOfOrders.Enqueue(quantities[i]);
            }

            Console.WriteLine(queueOfOrders.Max());

            int sumOfOrders = 0;

            bool isTrue = false;

            for (int i = 0; i < quantities.Length; i++)
            {
                int currentOrder = queueOfOrders.Peek();

                sumOfOrders += currentOrder;

                if (sumOfOrders <= quantityOfTheFood)
                {
                    queueOfOrders.Dequeue();
                    isTrue = true;
                }
                else
                {
                    isTrue = false;
                }
            }

            if (isTrue == true)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine("Orders left: " + string.Join(' ', queueOfOrders));
            }
        }
    }
}
