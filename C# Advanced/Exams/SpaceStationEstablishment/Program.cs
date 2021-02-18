using System;

namespace SpaceStationEstablishment
{
    public class Program
    {
        static void Main()
        {
            int sizeOfGalaxy = int.Parse(Console.ReadLine());

            char[][] galaxy = new char[sizeOfGalaxy][];

            for (int i = 0; i < sizeOfGalaxy; i++)
            {
                galaxy[i] = Console.ReadLine().ToCharArray();
            }

            int stephenRowIndex = 0;
            int stephenColIndex = 0;

            for (int row = 0; row < galaxy.Length; row++)
            {
                for (int col = 0; col < galaxy[row].Length; col++)
                {
                    if (galaxy[row][col] == 'S')
                    {
                        stephenRowIndex = row;
                        stephenColIndex = col;
                    }
                }
            }

            int starPower = 0;
            int currentStarPower = 0;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "up")
                {
                    if (stephenRowIndex == 0)
                    {
                        galaxy[stephenRowIndex][stephenColIndex] = '-';
                        Console.WriteLine("Bad news, the spaceship went to the void.");
                        Console.WriteLine($"Star power collected: {starPower}");

                        foreach (var row in galaxy)
                        {
                            Console.WriteLine(string.Join(string.Empty, row));
                        }

                        break;
                    }
                    else
                    {
                        if (galaxy[stephenRowIndex - 1][stephenColIndex] == '-')
                        {
                            galaxy[stephenRowIndex - 1][stephenColIndex] = 'S';
                            galaxy[stephenRowIndex][stephenColIndex] = '-';
                            stephenRowIndex--;
                        }
                        else if (int.TryParse(galaxy[stephenRowIndex - 1][stephenColIndex].ToString(), out currentStarPower))
                        {
                            starPower += currentStarPower;
                            galaxy[stephenRowIndex - 1][stephenColIndex] = 'S';
                            galaxy[stephenRowIndex][stephenColIndex] = '-';
                            stephenRowIndex--;

                            if (starPower >= 50)
                            {
                                Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
                                Console.WriteLine($"Star power collected: {starPower}");

                                foreach (var row in galaxy)
                                {
                                    Console.WriteLine(string.Join(string.Empty, row));
                                }

                                break;
                            }
                        }
                        else if (galaxy[stephenRowIndex - 1][stephenColIndex] == 'O')
                        {
                            int entryOfBlackHallRowIndex = stephenRowIndex - 1;
                            int entryOfBlackHallColIndex = stephenColIndex;

                            int exitOfBlackHallRowIndex = 0;
                            int exitOfBlackHallColIndex = 0;

                            for (int row = 0; row < galaxy.Length; row++)
                            {
                                for (int col = 0; col < galaxy[row].Length; col++)
                                {
                                    if (row != entryOfBlackHallRowIndex && col != entryOfBlackHallColIndex
                                        && galaxy[row][col] == 'O')
                                    {
                                        exitOfBlackHallRowIndex = row;
                                        exitOfBlackHallColIndex = col;
                                    }
                                }
                            }

                            galaxy[exitOfBlackHallRowIndex][exitOfBlackHallColIndex] = 'S';
                            galaxy[entryOfBlackHallRowIndex][entryOfBlackHallColIndex] = '-';
                            galaxy[stephenRowIndex][stephenColIndex] = '-';
                            stephenRowIndex = exitOfBlackHallRowIndex;
                            stephenColIndex = exitOfBlackHallColIndex;
                        }
                    }
                }
                else if (command == "down")
                {
                    if (stephenRowIndex == galaxy.Length - 1)
                    {
                        galaxy[stephenRowIndex][stephenColIndex] = '-';
                        Console.WriteLine("Bad news, the spaceship went to the void.");
                        Console.WriteLine($"Star power collected: {starPower}");

                        foreach (var row in galaxy)
                        {
                            Console.WriteLine(string.Join(string.Empty, row));
                        }

                        break;
                    }
                    else
                    {
                        if (galaxy[stephenRowIndex + 1][stephenColIndex] == '-')
                        {
                            galaxy[stephenRowIndex + 1][stephenColIndex] = 'S';
                            galaxy[stephenRowIndex][stephenColIndex] = '-';
                            stephenRowIndex++;
                        }
                        else if (int.TryParse(galaxy[stephenRowIndex + 1][stephenColIndex].ToString(), out currentStarPower))
                        {
                            starPower += currentStarPower;
                            galaxy[stephenRowIndex + 1][stephenColIndex] = 'S';
                            galaxy[stephenRowIndex][stephenColIndex] = '-';
                            stephenRowIndex++;

                            if (starPower >= 50)
                            {
                                Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
                                Console.WriteLine($"Star power collected: {starPower}");

                                foreach (var row in galaxy)
                                {
                                    Console.WriteLine(string.Join(string.Empty, row));
                                }

                                break;
                            }
                        }
                        else if (galaxy[stephenRowIndex + 1][stephenColIndex] == 'O')
                        {
                            int entryOfBlackHallRowIndex = stephenRowIndex + 1;
                            int entryOfBlackHallColIndex = stephenColIndex;

                            int exitOfBlackHallRowIndex = 0;
                            int exitOfBlackHallColIndex = 0;

                            for (int row = 0; row < galaxy.Length; row++)
                            {
                                for (int col = 0; col < galaxy[row].Length; col++)
                                {
                                    if (row != entryOfBlackHallRowIndex && col != entryOfBlackHallColIndex
                                        && galaxy[row][col] == 'O')
                                    {
                                        exitOfBlackHallRowIndex = row;
                                        exitOfBlackHallColIndex = col;
                                    }
                                }
                            }

                            galaxy[exitOfBlackHallRowIndex][exitOfBlackHallColIndex] = 'S';
                            galaxy[entryOfBlackHallRowIndex][entryOfBlackHallColIndex] = '-';
                            galaxy[stephenRowIndex][stephenColIndex] = '-';
                            stephenRowIndex = exitOfBlackHallRowIndex;
                            stephenColIndex = exitOfBlackHallColIndex;
                        }
                    }
                }
                else if (command == "left")
                {
                    if (stephenColIndex == 0)
                    {
                        galaxy[stephenRowIndex][stephenColIndex] = '-';
                        Console.WriteLine("Bad news, the spaceship went to the void.");
                        Console.WriteLine($"Star power collected: {starPower}");

                        foreach (var row in galaxy)
                        {
                            Console.WriteLine(string.Join(string.Empty, row));
                        }

                        break;
                    }
                    else
                    {
                        if (galaxy[stephenRowIndex][stephenColIndex - 1] == '-')
                        {
                            galaxy[stephenRowIndex][stephenColIndex - 1] = 'S';
                            galaxy[stephenRowIndex][stephenColIndex] = '-';
                            stephenColIndex--;
                        }
                        else if (int.TryParse(galaxy[stephenRowIndex][stephenColIndex - 1].ToString(), out currentStarPower))
                        {
                            starPower += currentStarPower;
                            galaxy[stephenRowIndex][stephenColIndex - 1] = 'S';
                            galaxy[stephenRowIndex][stephenColIndex] = '-';
                            stephenColIndex--;

                            if (starPower >= 50)
                            {
                                Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
                                Console.WriteLine($"Star power collected: {starPower}");

                                foreach (var row in galaxy)
                                {
                                    Console.WriteLine(string.Join(string.Empty, row));
                                }

                                break;
                            }
                        }
                        else if (galaxy[stephenRowIndex][stephenColIndex - 1] == 'O')
                        {
                            int entryOfBlackHallRowIndex = stephenRowIndex;
                            int entryOfBlackHallColIndex = stephenColIndex - 1;

                            int exitOfBlackHallRowIndex = 0;
                            int exitOfBlackHallColIndex = 0;

                            for (int row = 0; row < galaxy.Length; row++)
                            {
                                for (int col = 0; col < galaxy[row].Length; col++)
                                {
                                    if (row != entryOfBlackHallRowIndex && col != entryOfBlackHallColIndex
                                        && galaxy[row][col] == 'O')
                                    {
                                        exitOfBlackHallRowIndex = row;
                                        exitOfBlackHallColIndex = col;
                                    }
                                }
                            }

                            galaxy[exitOfBlackHallRowIndex][exitOfBlackHallColIndex] = 'S';
                            galaxy[entryOfBlackHallRowIndex][entryOfBlackHallColIndex] = '-';
                            galaxy[stephenRowIndex][stephenColIndex] = '-';
                            stephenRowIndex = exitOfBlackHallRowIndex;
                            stephenColIndex = exitOfBlackHallColIndex;
                        }
                    }
                }
                else if (command == "right")
                {
                    if (stephenColIndex == galaxy[0].Length - 1)
                    {
                        galaxy[stephenRowIndex][stephenColIndex] = '-';
                        Console.WriteLine("Bad news, the spaceship went to the void.");
                        Console.WriteLine($"Star power collected: {starPower}");

                        foreach (var row in galaxy)
                        {
                            Console.WriteLine(string.Join(string.Empty, row));
                        }

                        break;
                    }
                    else
                    {
                        if (galaxy[stephenRowIndex][stephenColIndex + 1] == '-')
                        {
                            galaxy[stephenRowIndex][stephenColIndex + 1] = 'S';
                            galaxy[stephenRowIndex][stephenColIndex] = '-';
                            stephenColIndex++;
                        }
                        else if (int.TryParse(galaxy[stephenRowIndex][stephenColIndex + 1].ToString(), out currentStarPower))
                        {
                            starPower += currentStarPower;
                            galaxy[stephenRowIndex][stephenColIndex + 1] = 'S';
                            galaxy[stephenRowIndex][stephenColIndex] = '-';
                            stephenColIndex++;

                            if (starPower >= 50)
                            {
                                Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
                                Console.WriteLine($"Star power collected: {starPower}");

                                foreach (var row in galaxy)
                                {
                                    Console.WriteLine(string.Join(string.Empty, row));
                                }

                                break;
                            }
                        }
                        else if (galaxy[stephenRowIndex][stephenColIndex + 1] == 'O')
                        {
                            int entryOfBlackHallRowIndex = stephenRowIndex;
                            int entryOfBlackHallColIndex = stephenColIndex + 1;

                            int exitOfBlackHallRowIndex = 0;
                            int exitOfBlackHallColIndex = 0;

                            for (int row = 0; row < galaxy.Length; row++)
                            {
                                for (int col = 0; col < galaxy[row].Length; col++)
                                {
                                    if (row != entryOfBlackHallRowIndex && col != entryOfBlackHallColIndex
                                        && galaxy[row][col] == 'O')
                                    {
                                        exitOfBlackHallRowIndex = row;
                                        exitOfBlackHallColIndex = col;
                                    }
                                }
                            }

                            galaxy[exitOfBlackHallRowIndex][exitOfBlackHallColIndex] = 'S';
                            galaxy[entryOfBlackHallRowIndex][entryOfBlackHallColIndex] = '-';
                            galaxy[stephenRowIndex][stephenColIndex] = '-';
                            stephenRowIndex = exitOfBlackHallRowIndex;
                            stephenColIndex = exitOfBlackHallColIndex;
                        }
                    }
                }
            }
        }
    }
}
