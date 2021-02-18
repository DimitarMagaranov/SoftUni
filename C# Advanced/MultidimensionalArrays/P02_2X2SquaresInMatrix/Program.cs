using System;
using System.Linq;

namespace P02_2X2SquaresInMatrix
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

            char[,] matrix = new char[sizeOfRol, sizeOfCol];

            for (int rol = 0; rol < sizeOfRol; rol++)
            {
                char[] array = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < array.Length; col++)
                {
                    matrix[rol, col] = array[col];
                }
            }

            int count = 0;

            for (int rol = 0; rol < sizeOfRol - 1; rol++)
            {
                for (int col = 0; col < sizeOfCol - 1; col++)
                {
                    if (matrix[rol,col] == matrix[rol, col + 1] && matrix[rol, col] == matrix[rol + 1, col]
                        && matrix[rol, col] == matrix[rol + 1, col + 1])
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}
