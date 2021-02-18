using System;
using System.Collections.Generic;
using System.Linq;

namespace Socks
{
    public class Program
    {
        static void Main()
        {
            Stack<int> leftSocks = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Queue<int> rightSocks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            List<int> pairs = new List<int>();

            while (leftSocks.Any() && rightSocks.Any())
            {
                int leftSock = leftSocks.Peek();
                int rightSock = rightSocks.Peek();

                if (leftSock > rightSock)
                {
                    int pair = leftSocks.Pop() + rightSocks.Dequeue();

                    pairs.Add(pair);
                }
                else if (rightSock > leftSock)
                {
                    leftSocks.Pop();
                }
                else if (leftSock == rightSock)
                {
                    rightSocks.Dequeue();
                    int incrementLeftSock = leftSocks.Pop() + 1;
                    leftSocks.Push(incrementLeftSock);
                }
            }

            Console.WriteLine(pairs.Max());
            Console.WriteLine(string.Join(" ", pairs));
        }
    }
}
