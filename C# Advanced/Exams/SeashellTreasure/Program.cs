using System;
using System.Collections.Generic;
using System.Linq;

namespace SeashellTreasure
{
    public class Program
    {
        static void Main()
        {
            int sizeOfBeach = int.Parse(Console.ReadLine());

            string[][] beach = new string[sizeOfBeach][];

            for (int i = 0; i < sizeOfBeach; i++)
            {
                beach[i] = Console.ReadLine().Split();
            }

            List<string> collectedSeashells = new List<string>();
            int countOfStolenSeashells = 0;

            while (true)
            {
                string[] tokens = Console.ReadLine().Split();

                if (tokens[0] == "Sunset")
                {
                    break;
                }

                if (tokens.Length == 3)
                {
                    int rowIndexToCollect = int.Parse(tokens[1]);
                    int colIndexToCollect = int.Parse(tokens[2]);

                    if (rowIndexToCollect <= beach.Length - 1 && colIndexToCollect <= beach[rowIndexToCollect].Length)
                    {
                        if (beach[rowIndexToCollect][colIndexToCollect] != "-")
                        {
                            collectedSeashells.Add(beach[rowIndexToCollect][colIndexToCollect]);
                            beach[rowIndexToCollect][colIndexToCollect] = "-";
                        }
                    }
                }
                else
                {
                    int rowIndexToSteal = int.Parse(tokens[1]);
                    int colIndexToSteal = int.Parse(tokens[2]);
                    string directionToNextSeashell = tokens[3];

                    if (rowIndexToSteal <= beach.Length - 1 && colIndexToSteal <= beach[rowIndexToSteal].Length)
                    {
                        if (beach[rowIndexToSteal][colIndexToSteal] != "-")
                        {
                            countOfStolenSeashells++;
                            beach[rowIndexToSteal][colIndexToSteal] = "-";
                        }

                        if (directionToNextSeashell == "up")
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                rowIndexToSteal--;

                                if (rowIndexToSteal >= 0 && colIndexToSteal <= beach[rowIndexToSteal].Length - 1 && beach[rowIndexToSteal][colIndexToSteal] != "-")
                                {
                                    countOfStolenSeashells++;
                                    beach[rowIndexToSteal][colIndexToSteal] = "-";
                                }
                            }
                        }
                        else if (directionToNextSeashell == "down")
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                rowIndexToSteal++;

                                if (rowIndexToSteal >= 0 && colIndexToSteal <= beach[rowIndexToSteal].Length - 1 && beach[rowIndexToSteal][colIndexToSteal] != "-")
                                {
                                    countOfStolenSeashells++;
                                    beach[rowIndexToSteal][colIndexToSteal] = "-";
                                }
                            }
                        }
                        else if (directionToNextSeashell == "left")
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                colIndexToSteal--;

                                if (colIndexToSteal >= 0 && beach[rowIndexToSteal][colIndexToSteal] != "-")
                                {
                                    countOfStolenSeashells++;
                                    beach[rowIndexToSteal][colIndexToSteal] = "-";
                                }
                            }
                        }
                        else if (directionToNextSeashell == "right")
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                colIndexToSteal++;

                                if (colIndexToSteal <= beach[rowIndexToSteal].Length - 1 && beach[rowIndexToSteal][colIndexToSteal] != "-")
                                {
                                    countOfStolenSeashells++;
                                    beach[rowIndexToSteal][colIndexToSteal] = "-";
                                }
                            }
                        }
                    }
                }
            }

            foreach (var row in beach)
            {
                Console.WriteLine(string.Join(" ", row));
            }

            if (collectedSeashells.Any())
            {
                Console.WriteLine($"Collected seashells: {collectedSeashells.Count} -> {string.Join(", ", collectedSeashells)}");
            }
            else
            {
                Console.WriteLine($"Collected seashells: 0");
            }

            Console.WriteLine($"Stolen seashells: {countOfStolenSeashells}");
        }
    }
}
