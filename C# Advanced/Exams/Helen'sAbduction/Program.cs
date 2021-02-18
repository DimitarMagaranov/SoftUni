using System;

namespace Helen_sAbduction
{
    public class Program
    {
        static void Main()
        {
            int energy = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());

            char[][] matrix = new char[rows][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();
            }

            int parisRowIndex = 0;
            int parisCollIndex = 0;

            int helenRowIndex = 0;
            int helenCollIndex = 0;


            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'P')
                    {
                        parisRowIndex = row;
                        parisCollIndex = col;
                    }
                    else if (matrix[row][col] == 'H')
                    {
                        helenRowIndex = row;
                        helenCollIndex = col;
                    }
                }
            }

            while (true)
            {
                string[] tokens = Console.ReadLine().Split();

                string command = tokens[0];
                int spartanRowIndex = int.Parse(tokens[1]);
                int spartanCollIndex = int.Parse(tokens[2]);

                matrix[spartanRowIndex][spartanCollIndex] = 'S';

                if (command == "up")
                {
                    if (parisRowIndex == 0)
                    {
                        energy--;

                        if (energy <= 0)
                        {
                            matrix[parisRowIndex][parisCollIndex] = 'X';
                            Console.WriteLine($"Paris died at {parisRowIndex};{parisCollIndex}.");
                            break;
                        }
                    }
                    else
                    {
                        if (matrix[parisRowIndex - 1][parisCollIndex] == '-')
                        {
                            energy--;

                            if (energy <= 0)
                            {
                                matrix[parisRowIndex - 1][parisCollIndex] = 'X';
                                matrix[parisRowIndex][parisCollIndex] = '-';
                                parisRowIndex--;
                                Console.WriteLine($"Paris died at {parisRowIndex};{parisCollIndex}.");
                                break;
                            }

                            matrix[parisRowIndex - 1][parisCollIndex] = 'P';
                            matrix[parisRowIndex][parisCollIndex] = '-';
                            parisRowIndex--;
                        }
                        else if (matrix[parisRowIndex - 1][parisCollIndex] == 'S')
                        {
                            energy -= 3;

                            if (energy <= 0)
                            {
                                matrix[parisRowIndex - 1][parisCollIndex] = 'X';
                                matrix[parisRowIndex][parisCollIndex] = '-';
                                parisRowIndex--;
                                Console.WriteLine($"Paris died at {parisRowIndex};{parisCollIndex}.");
                                break;
                            }
                            else
                            {
                                matrix[parisRowIndex - 1][parisCollIndex] = 'P';
                                matrix[parisRowIndex][parisCollIndex] = '-';
                            }
                            parisRowIndex--;
                        }
                        else
                        {
                            matrix[parisRowIndex - 1][parisCollIndex] = '-';
                            matrix[parisRowIndex][parisCollIndex] = '-';
                            energy--;
                            Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {energy}");
                            break;
                        }
                    }
                }
                else if (command == "down")
                {
                    if (parisRowIndex == matrix.Length - 1)
                    {
                        energy--;

                        if (energy <= 0)
                        {
                            matrix[parisRowIndex][parisCollIndex] = 'X';
                            Console.WriteLine($"Paris died at {parisRowIndex};{parisCollIndex}.");
                            break;
                        }
                    }
                    else
                    {
                        if (matrix[parisRowIndex + 1][parisCollIndex] == '-')
                        {
                            energy--;

                            if (energy <= 0)
                            {
                                matrix[parisRowIndex + 1][parisCollIndex] = 'X';
                                matrix[parisRowIndex][parisCollIndex] = '-';
                                parisRowIndex++;
                                Console.WriteLine($"Paris died at {parisRowIndex};{parisCollIndex}.");
                                break;
                            }

                            matrix[parisRowIndex + 1][parisCollIndex] = 'P';
                            matrix[parisRowIndex][parisCollIndex] = '-';
                            parisRowIndex++;
                        }
                        else if (matrix[parisRowIndex + 1][parisCollIndex] == 'S')
                        {
                            energy -= 3;

                            if (energy <= 0)
                            {
                                matrix[parisRowIndex + 1][parisCollIndex] = 'X';
                                matrix[parisRowIndex][parisCollIndex] = '-';
                                parisRowIndex++;
                                Console.WriteLine($"Paris died at {parisRowIndex};{parisCollIndex}.");
                                break;
                            }
                            else
                            {
                                matrix[parisRowIndex + 1][parisCollIndex] = 'P';
                                matrix[parisRowIndex][parisCollIndex] = '-';
                            }
                            parisRowIndex++;
                        }
                        else
                        {
                            matrix[parisRowIndex + 1][parisCollIndex] = '-';
                            matrix[parisRowIndex][parisCollIndex] = '-';
                            energy--;
                            Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {energy}");
                            break;
                        }
                    }
                }
                else if (command == "left")
                {
                    if (parisCollIndex == 0)
                    {
                        energy--;

                        if (energy <= 0)
                        {
                            matrix[parisRowIndex][parisCollIndex] = 'X';
                            Console.WriteLine($"Paris died at {parisRowIndex};{parisCollIndex}.");
                            break;
                        }
                    }
                    else
                    {
                        if (matrix[parisRowIndex][parisCollIndex - 1] == '-')
                        {
                            energy--;

                            if (energy <= 0)
                            {
                                matrix[parisRowIndex][parisCollIndex - 1] = 'X';
                                matrix[parisRowIndex][parisCollIndex] = '-';
                                parisCollIndex--;
                                Console.WriteLine($"Paris died at {parisRowIndex};{parisCollIndex}.");
                                break;
                            }

                            matrix[parisRowIndex][parisCollIndex - 1] = 'P';
                            matrix[parisRowIndex][parisCollIndex] = '-';
                            parisCollIndex--;
                        }
                        else if (matrix[parisRowIndex][parisCollIndex - 1] == 'S')
                        {
                            energy -= 3;

                            if (energy <= 0)
                            {
                                matrix[parisRowIndex][parisCollIndex - 1] = 'X';
                                matrix[parisRowIndex][parisCollIndex] = '-';
                                parisCollIndex--;
                                Console.WriteLine($"Paris died at {parisRowIndex};{parisCollIndex}.");
                                break;
                            }

                            matrix[parisRowIndex][parisCollIndex - 1] = 'P';
                            matrix[parisRowIndex][parisCollIndex] = '-';
                            parisCollIndex--;
                        }
                        else
                        {
                            matrix[parisRowIndex][parisCollIndex - 1] = '-';
                            matrix[parisRowIndex][parisCollIndex] = '-';
                            energy--;
                            Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {energy}");
                            break;
                        }
                    }
                }
                else
                {
                    if (parisCollIndex == matrix[parisRowIndex].Length - 1)
                    {
                        energy--;

                        if (energy <= 0)
                        {
                            matrix[parisRowIndex][parisCollIndex] = 'X';
                            Console.WriteLine($"Paris died at {parisRowIndex};{parisCollIndex}.");
                            break;
                        }
                    }
                    else
                    {
                        if (matrix[parisRowIndex][parisCollIndex + 1] == '-')
                        {
                            energy--;

                            if (energy <= 0)
                            {
                                matrix[parisRowIndex][parisCollIndex + 1] = 'X';
                                matrix[parisRowIndex][parisCollIndex] = '-';
                                parisCollIndex++;
                                Console.WriteLine($"Paris died at {parisRowIndex};{parisCollIndex}.");
                                break;
                            }

                            matrix[parisRowIndex][parisCollIndex + 1] = 'P';
                            matrix[parisRowIndex][parisCollIndex] = '-';
                            parisCollIndex++;
                        }
                        else if (matrix[parisRowIndex][parisCollIndex + 1] == 'S')
                        {
                            energy -= 3;

                            if (energy <= 0)
                            {
                                matrix[parisRowIndex][parisCollIndex + 1] = 'X';
                                matrix[parisRowIndex][parisCollIndex] = '-';
                                parisCollIndex++;
                                Console.WriteLine($"Paris died at {parisRowIndex};{parisCollIndex}.");
                                break;
                            }

                            matrix[parisRowIndex][parisCollIndex + 1] = 'P';
                            matrix[parisRowIndex][parisCollIndex] = '-';
                            parisCollIndex++;
                        }
                        else
                        {
                            matrix[parisRowIndex][parisCollIndex + 1] = '-';
                            matrix[parisRowIndex][parisCollIndex] = '-';
                            energy--;
                            Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {energy}");
                            break;
                        }
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
