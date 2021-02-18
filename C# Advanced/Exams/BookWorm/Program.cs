using System;
using System.Collections.Generic;
using System.Linq;

namespace BookWorm
{
    public class Program
    {
        static void Main()
        {
            List<char> worm = Console.ReadLine().ToCharArray().ToList();
            int sizeOfMatrix = int.Parse(Console.ReadLine());

            char[][] matrix = new char[sizeOfMatrix][];

            for (int i = 0; i < sizeOfMatrix; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();
            }

            int playerRowIndex = -1;
            int playerColIndex = -1;

            for (int row = 0; row < matrix.Length - 1; row++)
            {
                for (int col = 0; col < matrix[0].Length; col++)
                {
                    if (matrix[row][col] == 'P')
                    {
                        playerRowIndex = row;
                        playerColIndex = col;
                    }
                }
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                if (playerRowIndex < 0 || playerRowIndex > matrix.Length || playerColIndex < 0 || playerColIndex > matrix.GetLength(0))
                {
                    break;
                }

                if (command == "up")
                {
                    if (playerRowIndex == 0)
                    {
                        if (worm.Count > 0)
                        {
                            worm.RemoveAt(worm.Count - 1);
                        }
                        else
                        {
                            matrix[playerRowIndex][playerColIndex] = '-';
                            break;
                        }
                    }
                    else if (matrix[playerRowIndex - 1][playerColIndex] == '-')
                    {
                        matrix[playerRowIndex - 1][playerColIndex] = 'P';
                        matrix[playerRowIndex][playerColIndex] = '-';
                        playerRowIndex--;
                    }
                    else
                    {
                        worm.Add(matrix[playerRowIndex - 1][playerColIndex]);
                        matrix[playerRowIndex - 1][playerColIndex] = 'P';
                        matrix[playerRowIndex][playerColIndex] = '-';
                        playerRowIndex--;
                    }
                }
                else if (command == "down")
                {
                    if (playerRowIndex == matrix.Length - 1)
                    {
                        if (worm.Count > 0)
                        {
                            worm.RemoveAt(worm.Count - 1);
                        }
                        else
                        {
                            matrix[playerRowIndex][playerColIndex] = '-';
                            break;
                        }
                    }
                    else if (matrix[playerRowIndex + 1][playerColIndex] == '-')
                    {
                        matrix[playerRowIndex + 1][playerColIndex] = 'P';
                        matrix[playerRowIndex][playerColIndex] = '-';
                        playerRowIndex++;
                    }
                    else
                    {
                        worm.Add(matrix[playerRowIndex + 1][playerColIndex]);
                        matrix[playerRowIndex + 1][playerColIndex] = 'P';
                        matrix[playerRowIndex][playerColIndex] = '-';
                        playerRowIndex++;
                    }
                }
                else if (command == "left")
                {
                    if (playerColIndex == 0)
                    {
                        if (worm.Count > 0)
                        {
                            worm.RemoveAt(worm.Count - 1);
                        }
                        else
                        {
                            matrix[playerRowIndex][playerColIndex] = '-';
                            break;
                        }
                    }
                    else if (matrix[playerRowIndex][playerColIndex - 1] == '-')
                    {
                        matrix[playerRowIndex][playerColIndex - 1] = 'P';
                        matrix[playerRowIndex][playerColIndex] = '-';
                        playerColIndex--;
                    }
                    else
                    {
                        worm.Add(matrix[playerRowIndex][playerColIndex - 1]);
                        matrix[playerRowIndex][playerColIndex - 1] = 'P';
                        matrix[playerRowIndex][playerColIndex] = '-';
                        playerColIndex--;
                    }
                }
                else if (command == "right")
                {
                    if (playerColIndex == matrix[0].Length - 1)
                    {
                        if (worm.Count > 0)
                        {
                            worm.RemoveAt(worm.Count - 1);
                        }
                        else
                        {
                            matrix[playerRowIndex][playerColIndex] = '-';
                            break;
                        }
                    }
                    else if (matrix[playerRowIndex][playerColIndex + 1] == '-')
                    {
                        matrix[playerRowIndex][playerColIndex + 1] = 'P';
                        matrix[playerRowIndex][playerColIndex] = '-';
                        playerColIndex++;
                    }
                    else
                    {
                        worm.Add(matrix[playerRowIndex][playerColIndex + 1]);
                        matrix[playerRowIndex][playerColIndex + 1] = 'P';
                        matrix[playerRowIndex][playerColIndex] = '-';
                        playerColIndex++;
                    }
                }
            }

            Console.WriteLine(string.Join(string.Empty, worm));

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(string.Empty, row));
            }
        }
    }
}
