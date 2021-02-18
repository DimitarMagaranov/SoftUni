using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizesOfMatrix = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rolls = sizesOfMatrix[0];
            int columns = sizesOfMatrix[1];

            char[][] matrix = new char[rolls][];

            string snakeString = Console.ReadLine();

            Queue<char> snakeQueue = new Queue<char>(snakeString.ToCharArray());

            for (int rol = 0; rol < rolls; rol++)
            {
                matrix[rol] = new char[columns];

                for (int col = 0; col < columns; col++)
                {
                    char charToAdd = snakeQueue.Dequeue();
                    matrix[rol][col] = charToAdd;
                    snakeQueue.Enqueue(charToAdd);
                }
            }

            for (int i = 0; i < rolls; i++)
            {
                if (i % 2 != 0)
                {
                    string reversedString = string.Empty;

                    for (int j = columns - 1; j >= 0; j--)
                    {
                        reversedString += matrix[i][j];
                    }

                    matrix[i] = reversedString.ToCharArray();
                }
            }

            for (int i = 0; i < rolls; i++)
            {
                Console.WriteLine(string.Join(string.Empty, matrix[i]));
            }
        }
    }
}
