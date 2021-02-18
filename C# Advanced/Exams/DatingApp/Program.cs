using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatingApp
{
    public class Program
    {
        static void Main()
        {
            Stack<int> males = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Queue<int> females = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            int matchesCount = 0;

            while (males.Any() && females.Any())
            {
                int male = males.Peek();
                int female = females.Peek();

                if (male <= 0)
                {
                    males.Pop();
                    continue;
                }

                if (female <= 0)
                {
                    females.Dequeue();
                    continue;
                }

                if (females.Any() && males.Any())
                {
                    if (female % 25 == 0)
                    {
                        if (females.Count >= 2)
                        {
                            females.Dequeue();
                            females.Dequeue();
                        }
                        else
                        {
                            females.Dequeue();
                        }

                        continue;
                    }
                    else if (male % 25 == 0)
                    {

                        if (males.Count >= 2)
                        {
                            males.Pop();
                            males.Pop();
                        }
                        else
                        {
                            males.Pop();
                        }

                        continue;
                    }
                }

                if (male == female)
                {
                    if (males.Any() && females.Any())
                    {
                        males.Pop();
                        females.Dequeue();
                        matchesCount++;
                    }
                }
                else
                {
                    if (males.Any() && females.Any())
                    {
                        females.Dequeue();
                        males.Push(males.Pop() - 2);
                    }
                }
            }

            Console.WriteLine(Print(males, females, matchesCount));
        }

        public static string Print(Stack<int> males, Queue<int> females, int matchesCount)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Matches: {matchesCount}");

            if (males.Any() == false)
            {
                stringBuilder.AppendLine($"Males left: none");
            }
            else
            {
                stringBuilder.AppendLine($"Males left: {string.Join(", ", males)}");
            }

            if (females.Any() == false)
            {
                stringBuilder.AppendLine($"Females left: none");
            }
            else
            {
                stringBuilder.AppendLine($"Females left: {string.Join(", ", females)}");
            }

            return stringBuilder.ToString();
        }
    }
}
