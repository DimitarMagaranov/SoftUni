using System;
using System.Collections.Generic;
using System.Linq;

namespace ExcelFunctions
{
    class Program
    {
        static void Main()
        {
            int rowsColls = int.Parse(Console.ReadLine());

            string[][] matrix = new string[rowsColls][];

            for (int i = 0; i < rowsColls; i++)
            {
                matrix[i] = Console.ReadLine().Split(", ");
            }

            string[] commands = Console.ReadLine().Split();

            string command = string.Empty;
            string header = string.Empty;
            string value = string.Empty;
            
            if (commands.Length == 2)
            {
                command = commands[0];
                header = commands[1];

                if (command == "hide")
                {
                    int index = Array.IndexOf(matrix[0], header);

                    for (int i = 0; i < matrix.Length; i++)
                    {
                        List<string> printArray = matrix[i].ToList();
                        printArray.RemoveAt(index);
                        Console.WriteLine(string.Join(" | ", printArray));
                    }
                }
                else if (command == "sort")
                {
                    string[] headerRow = matrix[0];

                    Console.WriteLine(string.Join(" | ", matrix[0]));
                    
                    int index = Array.IndexOf(matrix[0], header);

                    matrix = matrix.OrderBy(x => x[index]).ToArray();

                    foreach (var row in matrix.Where(x => x != headerRow))
                    {
                        Console.WriteLine(string.Join(" | ", row));
                    }
                }
            }
            else
            {
                header = commands[1];
                value = commands[2];

                string[] headerRow = matrix[0];

                Console.WriteLine(string.Join(" | ", headerRow));

                int index = Array.IndexOf(headerRow, header);

                foreach (var row in matrix.Where(x => x[index] == value))
                {
                    Console.WriteLine(string.Join(" | ", row));
                }
            }
        }
    }
}
