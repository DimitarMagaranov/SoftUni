using System;
using System.Linq;

namespace P05_MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rolls = dimensions[0];
            int colls = dimensions[1];

            string[][] matrix = new string[rolls][];

            for (int i = 0; i < rolls; i++)
            {
                string[] elements = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

                if (elements.Length == colls)
                {
                    matrix[i] = elements;
                }
            }

            string[] tokens = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (tokens[0] != "END")
            {
                if (tokens.Length != 5 || tokens[0] != "swap")
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                int row1 = int.Parse(tokens[1]);
                int col1 = int.Parse(tokens[2]);
                int row2 = int.Parse(tokens[3]);
                int col2 = int.Parse(tokens[4]);

                if (Math.Max(row1, row2) > rolls - 1 || Math.Max(col1, col2) > colls - 1)
                {
                    Console.WriteLine("Invalid input!");
                }
                else
                {
                    string tmp = matrix[row1][col1];
                    matrix[row1][col1] = matrix[row2][col2];
                    matrix[row2][col2] = tmp;

                    for (int i = 0; i < rolls; i++)
                    {
                        Console.WriteLine(string.Join(' ', matrix[i]));
                    }
                }

                tokens = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }
        }
    }
}
