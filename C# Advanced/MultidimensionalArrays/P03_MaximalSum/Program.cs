using System;
using System.Linq;

namespace P03_MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int sizeOfRol = sizes[0];
            int sizeOfCol = sizes[1];

            int[,] matrix = new int[sizeOfRol, sizeOfCol];

            for (int rol = 0; rol < sizeOfRol; rol++)
            {
                int[] array = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < array.Length; col++)
                {
                    matrix[rol, col] = array[col];
                }
            }

            int sum = 0;
            int currRol = 0;
            int currCol = 0;

            for (int rol = 0; rol < sizeOfRol - 2; rol++)
            {
                for (int col = 0; col < sizeOfCol - 2; col++)
                {
                    int currSum = matrix[rol, col] + matrix[rol, col + 1] + matrix[rol, col + 2]
                        + matrix[rol + 1, col] + matrix[rol + 1, col + 1] + matrix[rol + 1, col + 2]
                        + matrix[rol + 2, col] + matrix[rol + 2, col + 1] + matrix[rol + 2, col + 2];

                    if (currSum > sum)
                    {
                        sum = currSum;
                        currRol = rol;
                        currCol = col;
                    }
                }
            }

            Console.WriteLine("Sum = {0}", sum);

            for (int i = currRol; i < currRol + 3; i++)
            {
                for (int j = currCol; j < currCol + 3; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
