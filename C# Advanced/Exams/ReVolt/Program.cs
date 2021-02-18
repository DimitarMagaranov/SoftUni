using System;
using System.Linq;

namespace ReVolt
{
    public class Program
    {
        static void Main(string[] args)
        {
            int matrixLength = int.Parse(Console.ReadLine());

            char[][] matrix = new char[matrixLength][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine().Split().Select(x => Convert.ToChar(x)).ToArray();
            }

            int playerRowIndex = 0;
            int playerColIndex = 0;

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[0].Length; col++)
                {
                    if (matrix[row][col] == 'f')
                    {
                        playerRowIndex = row;
                        playerColIndex = col;
                    }
                }
            }

            int commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                string command = Console.ReadLine();

                if (command == "up")
                {
                    if (playerRowIndex == 0)
                    {
                        if (matrix[matrix.Length - 1][playerColIndex] == '-')
                        {
                            matrix[matrix.Length - 1][playerColIndex] = 'f';
                            matrix[playerRowIndex][playerColIndex] = '-';
                            playerRowIndex = matrix.Length - 1;
                        }
                        else if (matrix[matrix.Length - 1][playerColIndex] == 'T')
                        {
                            continue;
                        }
                        else if (matrix[matrix.Length - 1][playerColIndex] == 'B')
                        {
                            if (matrix[matrix.Length - 2][playerColIndex] == '-')
                            {
                                matrix[matrix.Length - 2][playerColIndex] = 'f';
                                matrix[playerRowIndex][playerColIndex] = '-';
                                playerRowIndex = matrix.Length - 2;
                            }
                            else if (matrix[matrix.Length - 2][playerColIndex] == 'F')
                            {
                                matrix[matrix.Length - 2][playerColIndex] = 'f';
                                matrix[playerRowIndex][playerColIndex] = '-';
                                Console.WriteLine("Player won!");
                                foreach (var row in matrix)
                                {
                                    Console.WriteLine(row.ToString());
                                }
                                break;
                            }
                        }
                        else if (matrix[matrix.Length - 1][playerColIndex] == 'F')
                        {
                            matrix[matrix.Length - 1][playerColIndex] = 'f';
                            matrix[playerRowIndex][playerColIndex] = '-';
                            Console.WriteLine("Player won!");
                            foreach (var row in matrix)
                            {
                                Console.WriteLine(row.ToString());
                            }
                            break;
                        }
                    }
                    else
                    {
                        if (matrix[playerRowIndex - 1][playerColIndex] == '-')
                        {
                            matrix[playerRowIndex - 1][playerColIndex] = 'f';
                            matrix[playerRowIndex][playerColIndex] = '-';
                            playerRowIndex--;
                        }
                        else if (matrix[playerRowIndex - 1][playerColIndex] == 'T')
                        {
                            continue;
                        }
                        else if (matrix[playerRowIndex - 1][playerColIndex] == 'B')
                        {
                            if (matrix[matrix.Length - 2][playerColIndex] == '-')
                            {
                                matrix[matrix.Length - 2][playerColIndex] = 'f';
                                matrix[playerRowIndex][playerColIndex] = '-';
                                playerRowIndex = matrix.Length - 2;
                            }
                            else if (matrix[matrix.Length - 2][playerColIndex] == 'F')
                            {
                                matrix[matrix.Length - 2][playerColIndex] = 'f';
                                matrix[playerRowIndex][playerColIndex] = '-';
                                Console.WriteLine("Player won!");
                                foreach (var row in matrix)
                                {
                                    Console.WriteLine(row.ToString());
                                }
                                break;
                            }
                        }
                        else if (matrix[matrix.Length - 1][playerColIndex] == 'F')
                        {
                            matrix[matrix.Length - 1][playerColIndex] = 'f';
                            matrix[playerRowIndex][playerColIndex] = '-';
                            Console.WriteLine("Player won!");
                            foreach (var row in matrix)
                            {
                                Console.WriteLine(row.ToString());
                            }
                            break;
                        }
                    }
                }
            }
        }
    }
}
