using System;
using System.Linq;

namespace P01_DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[][] matrix = new int[size][];

            for (int i = 0; i < size; i++)
            {
                int[] currRol = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                matrix[i] = currRol;
            }

            int sumOfDiagonal1 = 0;
            int sumOfDiagonal2 = 0;

            for (int i = 0; i < size; i++)
            {
                sumOfDiagonal1 += matrix[i][i];
            }

            for (int rol = 0, col = size - 1; rol < size; rol++, col--)
            {
                sumOfDiagonal2 += matrix[rol][col];
            }

            Console.WriteLine(Math.Abs(sumOfDiagonal1 - sumOfDiagonal2));
        }
    }
}
