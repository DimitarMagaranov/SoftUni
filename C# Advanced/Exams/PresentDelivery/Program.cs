using System;
using System.Linq;

namespace PresentDelivery
{
    public class Program
    {
        static void Main()
        {
            int santaPresents = int.Parse(Console.ReadLine());
            int sizeOfMatrix = int.Parse(Console.ReadLine());

            char[][] matrix = new char[sizeOfMatrix][];

            for (int i = 0; i < sizeOfMatrix; i++)
            {
                matrix[i] = Console.ReadLine().Split().Select(x => Convert.ToChar(x)).ToArray();
            }

            int santaRowIndex = 0;
            int santaColIndex = 0;

            int[] niceKIds = new int[2];

            int countOfNiceKids = 0;

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix.GetLength(0); col++)
                {
                    if (matrix[row][col] == 'S')
                    {
                        santaRowIndex = row;
                        santaColIndex = col;
                    }
                    else if (matrix[row][col] == 'V')
                    {
                        countOfNiceKids++;
                    }
                }
            }

            int niceKidsToTakePresents = countOfNiceKids;

            niceKIds[0] = countOfNiceKids;
            niceKIds[1] = niceKidsToTakePresents;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Christmas morning")
                {
                    break;
                }

                if (command == "up")
                {
                    if (santaRowIndex == 0)
                    {
                        continue;
                    }

                    if (matrix[santaRowIndex - 1][santaColIndex] == '-' || matrix[santaRowIndex - 1][santaColIndex] == 'X')
                    {
                        matrix[santaRowIndex - 1][santaColIndex] = 'S';
                        matrix[santaRowIndex][santaColIndex] = '-';
                        santaRowIndex--;
                    }
                    else if (matrix[santaRowIndex - 1][santaColIndex] == 'V')
                    {
                        matrix[santaRowIndex - 1][santaColIndex] = 'S';
                        matrix[santaRowIndex][santaColIndex] = '-';
                        niceKIds[0]--;
                        santaPresents--;
                        santaRowIndex--;

                        if (santaPresents == 0)
                        {
                            Console.WriteLine("Santa ran out of presents.");
                            break;
                        }
                    }
                    else if (matrix[santaRowIndex - 1][santaColIndex] == 'C')
                    {
                        matrix[santaRowIndex - 1][santaColIndex] = 'S';
                        matrix[santaRowIndex][santaColIndex] = '-';
                        santaRowIndex--;

                        if (CheckForKids(matrix, santaRowIndex, santaColIndex, santaPresents, countOfNiceKids) == false)
                        {
                            break;
                        }
                    }
                }
                if (command == "down")
                {
                    if (santaRowIndex == matrix.Length - 1)
                    {
                        continue;
                    }

                    if (matrix[santaRowIndex + 1][santaColIndex] == '-' || matrix[santaRowIndex + 1][santaColIndex] == 'X')
                    {
                        matrix[santaRowIndex + 1][santaColIndex] = 'S';
                        matrix[santaRowIndex][santaColIndex] = '-';
                        santaRowIndex++;
                    }
                    else if (matrix[santaRowIndex + 1][santaColIndex] == 'V')
                    {
                        matrix[santaRowIndex + 1][santaColIndex] = 'S';
                        matrix[santaRowIndex][santaColIndex] = '-';
                        countOfNiceKids--;
                        santaPresents--;
                        santaRowIndex++;

                        if (santaPresents == 0)
                        {
                            Console.WriteLine("Santa ran out of presents.");
                            break;
                        }
                    }
                    else if (matrix[santaRowIndex + 1][santaColIndex] == 'C')
                    {
                        matrix[santaRowIndex + 1][santaColIndex] = 'S';
                        matrix[santaRowIndex][santaColIndex] = '-';
                        santaRowIndex++;

                        if (CheckForKids(matrix, santaRowIndex, santaColIndex, santaPresents, countOfNiceKids) == false)
                        {
                            break;
                        }
                    }
                }
                if (command == "left")
                {
                    if (santaColIndex == 0)
                    {
                        continue;
                    }

                    if (matrix[santaRowIndex][santaColIndex - 1] == '-' || matrix[santaRowIndex][santaColIndex - 1] == 'X')
                    {
                        matrix[santaRowIndex][santaColIndex - 1] = 'S';
                        matrix[santaRowIndex][santaColIndex] = '-';
                        santaColIndex--;
                    }
                    else if (matrix[santaRowIndex][santaColIndex - 1] == 'V')
                    {
                        matrix[santaRowIndex][santaColIndex - 1] = 'S';
                        matrix[santaRowIndex][santaColIndex] = '-';
                        countOfNiceKids--;
                        santaPresents--;
                        santaColIndex--;

                        if (santaPresents == 0)
                        {
                            Console.WriteLine("Santa ran out of presents.");
                            break;
                        }
                    }
                    else if (matrix[santaRowIndex][santaColIndex - 1] == 'C')
                    {
                        matrix[santaRowIndex][santaColIndex - 1] = 'S';
                        matrix[santaRowIndex][santaColIndex] = '-';
                        santaColIndex--;

                        if (CheckForKids(matrix, santaRowIndex, santaColIndex, santaPresents, countOfNiceKids) == false)
                        {
                            break;
                        }
                    }
                }

                if (command == "right")
                {
                    if (santaColIndex == matrix.GetLength(0) - 1)
                    {
                        continue;
                    }

                    if (matrix[santaRowIndex][santaColIndex + 1] == '-' || matrix[santaRowIndex][santaColIndex + 1] == 'X')
                    {
                        matrix[santaRowIndex][santaColIndex + 1] = 'S';
                        matrix[santaRowIndex][santaColIndex] = '-';
                        santaColIndex++;
                    }
                    else if (matrix[santaRowIndex][santaColIndex + 1] == 'V')
                    {
                        matrix[santaRowIndex][santaColIndex + 1] = 'S';
                        matrix[santaRowIndex][santaColIndex] = '-';
                        countOfNiceKids--;
                        santaPresents--;
                        santaColIndex++;

                        if (santaPresents == 0)
                        {
                            Console.WriteLine("Santa ran out of presents.");
                            break;
                        }
                    }
                    else if (matrix[santaRowIndex][santaColIndex + 1] == 'C')
                    {
                        matrix[santaRowIndex][santaColIndex + 1] = 'S';
                        matrix[santaRowIndex][santaColIndex] = '-';
                        santaColIndex++;

                        if (CheckForKids(matrix, santaRowIndex, santaColIndex, santaPresents, countOfNiceKids) == false)
                        {
                            break;
                        }
                    }
                }
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }

            if (countOfNiceKids == 0)
            {
                Console.WriteLine($"Good job, Santa! {niceKidsToTakePresents} happy nice kid/s.");
            }
            else
            {
                Console.WriteLine($"No presents for {countOfNiceKids} nice kid/s.");
            }
        }

        public static bool CheckForKids(char[][] matrix, int santaRowIndex, int santaColIndex, int santaPresents, int countOfNiceKids)
        {
            bool isTherePresents = true;

            // case(up)
            if (matrix[santaRowIndex - 1][santaColIndex] != '-' && matrix[santaRowIndex - 1][santaColIndex] == 'V')
            {
                matrix[santaRowIndex - 1][santaColIndex] = '-';
                santaPresents--;
                countOfNiceKids--;

                if (santaPresents == 0)
                {
                    Console.WriteLine("Santa ran out of presents.");
                    return isTherePresents = false;
                }
            }
            else if (matrix[santaRowIndex - 1][santaColIndex] != '-' && matrix[santaRowIndex - 1][santaColIndex] == 'X')
            {
                matrix[santaRowIndex - 1][santaColIndex] = '-';
                santaPresents--;

                if (santaPresents == 0)
                {
                    Console.WriteLine("Santa ran out of presents.");
                    return isTherePresents = false;
                }
            }

            //case(down)
            if (matrix[santaRowIndex + 1][santaColIndex] != '-' && matrix[santaRowIndex + 1][santaColIndex] == 'V')
            {
                matrix[santaRowIndex + 1][santaColIndex] = '-';
                santaPresents--;
                countOfNiceKids--;

                if (santaPresents == 0)
                {
                    Console.WriteLine("Santa ran out of presents.");
                    return isTherePresents = false;
                }
            }
            else if (matrix[santaRowIndex + 1][santaColIndex] != '-' && matrix[santaRowIndex + 1][santaColIndex] == 'X')
            {
                matrix[santaRowIndex + 1][santaColIndex] = '-';
                santaPresents--;

                if (santaPresents == 0)
                {
                    Console.WriteLine("Santa ran out of presents.");
                    return isTherePresents = false;
                }
            }

            //case(left)
            if (matrix[santaRowIndex][santaColIndex - 1] != '-' && matrix[santaRowIndex][santaColIndex - 1] == 'V')
            {
                matrix[santaRowIndex][santaColIndex - 1] = '-';
                santaPresents--;
                countOfNiceKids--;

                if (santaPresents == 0)
                {
                    Console.WriteLine("Santa ran out of presents.");
                    return isTherePresents = false;
                }
            }
            else if (matrix[santaRowIndex][santaColIndex - 1] != '-' && matrix[santaRowIndex][santaColIndex - 1] == 'X')
            {
                matrix[santaRowIndex][santaColIndex - 1] = '-';
                santaPresents--;

                if (santaPresents == 0)
                {
                    Console.WriteLine("Santa ran out of presents.");
                    return isTherePresents = false;
                }
            }

            //case(right)
            if (matrix[santaRowIndex][santaColIndex + 1] != '-' && matrix[santaRowIndex][santaColIndex + 1] == 'V')
            {
                matrix[santaRowIndex][santaColIndex + 1] = '-';
                santaPresents--;
                countOfNiceKids--;

                if (santaPresents == 0)
                {
                    Console.WriteLine("Santa ran out of presents.");
                    return isTherePresents = false;
                }
            }
            else if (matrix[santaRowIndex][santaColIndex + 1] != '-' && matrix[santaRowIndex][santaColIndex + 1] == 'X')
            {
                matrix[santaRowIndex][santaColIndex + 1] = '-';
                santaPresents--;

                if (santaPresents == 0)
                {
                    Console.WriteLine("Santa ran out of presents.");
                    return isTherePresents = false;
                }
            }

            return isTherePresents;
        }
    }
}
