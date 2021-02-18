using System;
using System.Collections.Generic;
using System.Linq;

namespace CollectingEggs
{
    public class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());

            char[][] matrix = new char[sizeMatrix][];

            for (int row = 0; row < matrix.Length; row++)
            {
                char[] line = Console.ReadLine().ToCharArray();

                matrix[row] = line.Where(x => x != ' ').ToArray();
            }

            int playerRowIndex = 0;
            int playerColIndex = 0;

            int countOfEggs = 0;
            int firstCountOfEggs = 0;

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[0].Length; col++)
                {
                    if (matrix[row][col] == 'B')
                    {
                        playerRowIndex = row;
                        playerColIndex = col;
                    }
                    else if (matrix[row][col] != 'C' && matrix[row][col] != '-')
                    {
                        countOfEggs++;
                        firstCountOfEggs++;
                    }
                }
            }

            List<char> basket = new List<char>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                //if (basket.Count == firstCountOfEggs)
                //{
                //    Console.WriteLine($"The Easter bunny failed to gather every egg. There are {countOfEggs} eggs left to collect.");

                //    foreach (var row in matrix)
                //    {
                //        Console.WriteLine(string.Join(' ', row));
                //    }

                //    break;
                //}

                if (command == "up")
                {
                    if (playerRowIndex == 0)
                    {
                        if (basket.Any())
                        {
                            basket.RemoveAt(0);
                        }

                        continue;
                    }

                    if (matrix[playerRowIndex - 1][playerColIndex] == '-')
                    {
                        matrix[playerRowIndex - 1][playerColIndex] = 'B';
                        matrix[playerRowIndex][playerColIndex] = '-';
                        playerRowIndex--;
                    }
                    else if (matrix[playerRowIndex - 1][playerColIndex] == 'C')
                    {
                        matrix[playerRowIndex - 1][playerColIndex] = '-';

                        //ako morkova e na pyrviq red
                        if (playerRowIndex - 1 == 0)
                        {
                            if (matrix[matrix.Length - 1][playerColIndex] == '-')
                            {
                                matrix[matrix.Length - 1][playerColIndex] = 'B';
                                matrix[playerRowIndex][playerColIndex] = '-';

                                playerRowIndex = matrix.Length - 1;
                            }
                            else
                            {
                                basket.Add(matrix[matrix.Length - 1][playerColIndex]);
                                countOfEggs--;

                                matrix[matrix.Length - 1][playerColIndex] = 'B';
                                matrix[playerRowIndex][playerColIndex] = '-';

                                playerRowIndex = matrix.Length - 1;
                            }
                        }
                        else
                        {
                            if (matrix[0][playerColIndex] == '-')
                            {
                                matrix[0][playerColIndex] = 'B';
                                matrix[playerRowIndex][playerColIndex] = '-';

                                playerRowIndex = 0;
                            }
                            else
                            {
                                basket.Add(matrix[0][playerColIndex]);
                                countOfEggs--;

                                matrix[0][playerColIndex] = 'B';
                                matrix[playerRowIndex][playerColIndex] = '-';

                                playerRowIndex = 0;
                            }
                        }
                    }
                    else
                    {
                        basket.Add(matrix[playerRowIndex - 1][playerColIndex]);
                        countOfEggs--;
                        matrix[playerRowIndex - 1][playerColIndex] = 'B';
                        matrix[playerRowIndex][playerColIndex] = '-';
                        playerRowIndex--;
                    }
                }
                else if (command == "down")
                {
                    if (playerRowIndex == matrix.Length - 1)
                    {
                        if (basket.Any())
                        {
                            basket.RemoveAt(0);
                        }

                        continue;
                    }

                    if (matrix[playerRowIndex + 1][playerColIndex] == '-')
                    {
                        matrix[playerRowIndex + 1][playerColIndex] = 'B';
                        matrix[playerRowIndex][playerColIndex] = '-';
                        playerRowIndex++;
                    }
                    else if (matrix[playerRowIndex + 1][playerColIndex] == 'C')
                    {
                        matrix[playerRowIndex + 1][playerColIndex] = '-';

                        //ako morkova e na posledniq red
                        if (playerRowIndex + 1 == 0)
                        {
                            if (matrix[0][playerColIndex] == '-')
                            {
                                matrix[0][playerColIndex] = 'B';
                                matrix[playerRowIndex][playerColIndex] = '-';

                                playerRowIndex = 0;
                            }
                            else
                            {
                                basket.Add(matrix[0][playerColIndex]);
                                countOfEggs--;

                                matrix[0][playerColIndex] = 'B';
                                matrix[playerRowIndex][playerColIndex] = '-';

                                playerRowIndex = 0;
                            }
                        }
                        else
                        {
                            if (matrix[matrix.Length - 1][playerColIndex] == '-')
                            {
                                matrix[matrix.Length - 1][playerColIndex] = 'B';
                                matrix[playerRowIndex][playerColIndex] = '-';

                                playerRowIndex = matrix.Length - 1;
                            }
                            else
                            {
                                basket.Add(matrix[matrix.Length - 1][playerColIndex]);
                                countOfEggs--;

                                matrix[matrix.Length - 1][playerColIndex] = 'B';
                                matrix[playerRowIndex][playerColIndex] = '-';

                                playerRowIndex = matrix.Length - 1;
                            }
                        }
                    }
                    else
                    {
                        basket.Add(matrix[playerRowIndex + 1][playerColIndex]);
                        countOfEggs--;
                        matrix[playerRowIndex + 1][playerColIndex] = 'B';
                        matrix[playerRowIndex][playerColIndex] = '-';
                        playerRowIndex++;
                    }
                }
                else if (command == "left")
                {
                    if (playerColIndex == 0)
                    {
                        if (basket.Any())
                        {
                            basket.RemoveAt(0);
                        }

                        continue;
                    }

                    if (matrix[playerRowIndex][playerColIndex - 1] == '-')
                    {
                        matrix[playerRowIndex][playerColIndex - 1] = 'B';
                        matrix[playerRowIndex][playerColIndex] = '-';
                        playerColIndex--;
                    }
                    else if (matrix[playerRowIndex][playerColIndex - 1] == 'C')
                    {
                        matrix[playerRowIndex][playerColIndex - 1] = '-';

                        //ako morkova e na posledniq red
                        if (playerColIndex - 1 == 0)
                        {
                            if (matrix[playerRowIndex][matrix.Length - 1] == '-')
                            {
                                matrix[playerRowIndex][matrix.Length - 1] = 'B';
                                matrix[playerRowIndex][playerColIndex] = '-';

                                playerColIndex = matrix.Length - 1;
                            }
                            else
                            {
                                basket.Add(matrix[playerRowIndex][matrix.Length - 1]);
                                countOfEggs--;

                                matrix[playerRowIndex][matrix.Length - 1] = 'B';
                                matrix[playerRowIndex][playerColIndex] = '-';

                                playerColIndex = matrix.Length - 1;
                            }
                        }
                        else
                        {
                            if (matrix[playerRowIndex][0] == '-')
                            {
                                matrix[playerRowIndex][0] = 'B';
                                matrix[playerRowIndex][playerColIndex] = '-';

                                playerColIndex = 0;
                            }
                            else
                            {
                                basket.Add(matrix[playerRowIndex][0]);
                                countOfEggs--;

                                matrix[playerRowIndex][0] = 'B';
                                matrix[playerRowIndex][playerColIndex] = '-';

                                playerColIndex = 0;
                            }
                        }
                    }
                    else
                    {
                        basket.Add(matrix[playerRowIndex][playerColIndex - 1]);
                        countOfEggs--;
                        matrix[playerRowIndex][playerColIndex - 1] = 'B';
                        matrix[playerRowIndex][playerColIndex] = '-';
                        playerColIndex--;
                    }
                }
                else if (command == "right")
                {
                    if (playerColIndex == matrix.Length - 1)
                    {
                        if (basket.Any())
                        {
                            basket.RemoveAt(0);
                        }

                        continue;
                    }

                    if (matrix[playerRowIndex][playerColIndex + 1] == '-')
                    {
                        matrix[playerRowIndex][playerColIndex + 1] = 'B';
                        matrix[playerRowIndex][playerColIndex] = '-';
                        playerColIndex++;
                    }
                    else if (matrix[playerRowIndex][playerColIndex + 1] == 'C')
                    {
                        matrix[playerRowIndex][playerColIndex + 1] = '-';

                        //ako morkova e na posledniq red
                        if (playerColIndex + 1 == matrix.Length - 1)
                        {
                            if (matrix[playerRowIndex][0] == '-')
                            {
                                matrix[playerRowIndex][0] = 'B';
                                matrix[playerRowIndex][playerColIndex] = '-';

                                playerColIndex = 0;
                            }
                            else
                            {
                                basket.Add(matrix[playerRowIndex][0]);
                                countOfEggs--;

                                matrix[playerRowIndex][0] = 'B';
                                matrix[playerRowIndex][playerColIndex] = '-';

                                playerColIndex = 0;
                            }
                        }
                        else
                        {
                            if (matrix[playerRowIndex][matrix.Length - 1] == '-')
                            {
                                matrix[playerRowIndex][matrix.Length - 1] = 'B';
                                matrix[playerRowIndex][playerColIndex] = '-';

                                playerColIndex = matrix.Length - 1;
                            }
                            else
                            {
                                basket.Add(matrix[playerRowIndex][matrix.Length - 1]);
                                countOfEggs--;

                                matrix[playerRowIndex][matrix.Length - 1] = 'B';
                                matrix[playerRowIndex][playerColIndex] = '-';

                                playerColIndex = matrix.Length - 1;
                            }
                        }
                    }
                    else
                    {
                        basket.Add(matrix[playerRowIndex][playerColIndex + 1]);
                        countOfEggs--;
                        matrix[playerRowIndex][playerColIndex + 1] = 'B';
                        matrix[playerRowIndex][playerColIndex] = '-';
                        playerColIndex++;
                    }
                }

                if (countOfEggs == 0)
                {
                    break;
                }
            }


            if (basket.Count == firstCountOfEggs)
            {
                Console.WriteLine($"Happy Easter! The Easter bunny collected {countOfEggs} eggs: ");
                Console.Write(string.Join(", ", basket));
                Console.Write(".");
            }
            else
            {
                Console.WriteLine($"The Easter bunny failed to gather every egg. There are {countOfEggs} eggs left to collect.");
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(' ', row));
            }
        }
    }
}
