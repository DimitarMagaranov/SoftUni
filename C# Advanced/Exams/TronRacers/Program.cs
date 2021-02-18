using System;
using System.Linq;

namespace TronRacers
{
    public class Program
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            char[][] matrix = new char[size][];

            for (int i = 0; i < size; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();
            }

            int firstPlayerIndexRow = 0;
            int firstPlayerIndexColl = 0;

            int secondPlayerIndexRow = 0;
            int secondPlayerIndexColl = 0;

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int coll = 0; coll < matrix[row].Length; coll++)
                {
                    if (matrix[row][coll] == 'f')
                    {
                        firstPlayerIndexRow = row;
                        firstPlayerIndexColl = coll;
                    }
                    else if (matrix[row][coll] == 's')
                    {
                        secondPlayerIndexRow = row;
                        secondPlayerIndexColl = coll;
                    }
                }
            }

            while (true)
            {
                string[] commands = Console.ReadLine().Split();

                string firstPlayerCommand = commands[0];
                string secondPlayerCommand = commands[1];
                
                if (firstPlayerCommand == "up")
                {
                    if (firstPlayerIndexRow == 0)
                    {
                        firstPlayerIndexRow = matrix.Length - 1;
                    }
                    else
                    {
                        firstPlayerIndexRow--;
                    }

                    if (matrix[firstPlayerIndexRow][firstPlayerIndexColl] == '*')
                    {
                        matrix[firstPlayerIndexRow][firstPlayerIndexColl] = 'f';
                    }
                    else if (matrix[firstPlayerIndexRow][firstPlayerIndexColl] == 's')
                    {
                        matrix[firstPlayerIndexRow][firstPlayerIndexColl] = 'x';
                        break;
                    }
                }
                else if (firstPlayerCommand == "down")
                {
                    if (firstPlayerIndexRow == matrix.Length - 1)
                    {
                        firstPlayerIndexRow = 0;
                    }
                    else
                    {
                        firstPlayerIndexRow++;
                    }

                    if (matrix[firstPlayerIndexRow][firstPlayerIndexColl] == '*')
                    {
                        matrix[firstPlayerIndexRow][firstPlayerIndexColl] = 'f';
                    }
                    else if (matrix[firstPlayerIndexRow][firstPlayerIndexColl] == 's')
                    {
                        matrix[firstPlayerIndexRow][firstPlayerIndexColl] = 'x';
                        break;
                    }
                }
                else if (firstPlayerCommand == "left")
                {
                    if (firstPlayerIndexColl == 0)
                    {
                        firstPlayerIndexColl = matrix[0].Length - 1;
                    }
                    else
                    {
                        firstPlayerIndexColl--;
                    }

                    if (matrix[firstPlayerIndexRow][firstPlayerIndexColl] == '*')
                    {
                        matrix[firstPlayerIndexRow][firstPlayerIndexColl] = 'f';
                    }
                    else if (matrix[firstPlayerIndexRow][firstPlayerIndexColl] == 's')
                    {
                        matrix[firstPlayerIndexRow][firstPlayerIndexColl] = 'x';
                        break;
                    }
                }
                else
                {
                    if (firstPlayerIndexColl == matrix[firstPlayerIndexRow].Length - 1)
                    {
                        firstPlayerIndexColl = 0;
                    }
                    else
                    {
                        firstPlayerIndexColl++;
                    }

                    if (matrix[firstPlayerIndexRow][firstPlayerIndexColl] == '*')
                    {
                        matrix[firstPlayerIndexRow][firstPlayerIndexColl] = 'f';
                    }
                    else if (matrix[firstPlayerIndexRow][firstPlayerIndexColl] == 's')
                    {
                        matrix[firstPlayerIndexRow][firstPlayerIndexColl] = 'x';
                        break;
                    }
                }

                if (secondPlayerCommand == "up")
                {
                    if (secondPlayerIndexRow == 0)
                    {
                        secondPlayerIndexRow = matrix.Length - 1;
                    }
                    else
                    {
                        secondPlayerIndexRow--;
                    }

                    if (matrix[secondPlayerIndexRow][secondPlayerIndexColl] == '*')
                    {
                        matrix[secondPlayerIndexRow][secondPlayerIndexColl] = 's';
                    }
                    else if (matrix[secondPlayerIndexRow][secondPlayerIndexColl] == 'f')
                    {
                        matrix[secondPlayerIndexRow][secondPlayerIndexColl] = 'x';
                        break;
                    }
                }
                else if (secondPlayerCommand == "down")
                {
                    if (secondPlayerIndexRow == matrix.Length - 1)
                    {
                        secondPlayerIndexRow = 0;
                    }
                    else
                    {
                        secondPlayerIndexRow++;
                    }

                    if (matrix[secondPlayerIndexRow][secondPlayerIndexColl] == '*')
                    {
                        matrix[secondPlayerIndexRow][secondPlayerIndexColl] = 's';
                    }
                    else if (matrix[secondPlayerIndexRow][secondPlayerIndexColl] == 'f')
                    {
                        matrix[secondPlayerIndexRow][secondPlayerIndexColl] = 'x';
                        break;
                    }
                }
                else if (secondPlayerCommand == "left")
                {
                    if (secondPlayerIndexColl == 0)
                    {
                        secondPlayerIndexColl = matrix[0].Length - 1;
                    }
                    else
                    {
                        secondPlayerIndexColl--;
                    }

                    if (matrix[secondPlayerIndexRow][secondPlayerIndexColl] == '*')
                    {
                        matrix[secondPlayerIndexRow][secondPlayerIndexColl] = 's';
                    }
                    else if (matrix[secondPlayerIndexRow][secondPlayerIndexColl] == 'f')
                    {
                        matrix[secondPlayerIndexRow][secondPlayerIndexColl] = 'x';
                        break;
                    }
                }
                else
                {
                    if (secondPlayerIndexColl == matrix[secondPlayerIndexRow].Length - 1)
                    {
                        secondPlayerIndexColl = 0;
                    }
                    else
                    {
                        secondPlayerIndexColl++;
                    }

                    if (matrix[secondPlayerIndexRow][secondPlayerIndexColl] == '*')
                    {
                        matrix[secondPlayerIndexRow][secondPlayerIndexColl] = 's';
                    }
                    else if (matrix[secondPlayerIndexRow][secondPlayerIndexColl] == 'f')
                    {
                        matrix[secondPlayerIndexRow][secondPlayerIndexColl] = 'x';
                        break;
                    }
                }
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(string.Empty, row));
            }
        }
    }
}
