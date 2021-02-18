using System;
using System.Collections.Generic;
using System.Linq;

namespace TrojanInvasion
{
    public class Program
    {
        static void Main()
        {
            int countOfTrojanWaves = int.Parse(Console.ReadLine());

            Stack<int> plates = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).Reverse());
            Stack<int> warriors = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            int warriorToAtack;
            int plate;

            for (int i = 1; i <= countOfTrojanWaves; i++)
            {
                if (i % 3 == 0)
                {
                    plates.Push(int.Parse(Console.ReadLine()));
                    int[] reversedStack = plates.ToArray();
                    plates = new Stack<int>(reversedStack);
                }

                while (warriors.Any())
                {
                    if (plates.Any() == false)
                    {
                        Console.WriteLine("The Trojans successfully destroyed the Spartan defense.");
                        Console.WriteLine($"Warriors left: {string.Join(", ", warriors)}");
                        return;
                    }

                    warriorToAtack = warriors.Peek();
                    plate = plates.Peek();

                    if (warriorToAtack < plate)
                    {
                        warriors.Pop();
                        int currPlate = plates.Pop();
                        plates.Push(currPlate - warriorToAtack);
                    }
                    else if (warriorToAtack > plate)
                    {
                        int currWarrior = warriorToAtack - plate;
                        plates.Pop();
                        warriors.Pop();
                        warriors.Push(currWarrior);
                    }
                    else
                    {
                        warriors.Pop();
                        plates.Pop();
                    }
                }

                if (i == countOfTrojanWaves)
                {
                    break;
                }

                warriors = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            }

            if (warriors.Any() == false)
            {
                Console.WriteLine("The Spartans successfully repulsed the Trojan attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
        }
    }
}
