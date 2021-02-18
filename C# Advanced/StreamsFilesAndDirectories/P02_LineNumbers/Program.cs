using System;
using System.IO;

namespace P02_LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader(@"..\..\..\text.txt"))
            {
                int lineCounter = 1;

                using (StreamWriter writer = new StreamWriter(@"..\..\..\output.txt"))
                {
                    while (true)
                    {
                        string line = reader.ReadLine();

                        if (line == null)
                        {
                            break;
                        }

                        int counterOfLetters = 0;
                        int counterOfSymbols = 0;

                        foreach (var charr in line)
                        {
                            if (Char.IsLetter(charr))
                            {
                                counterOfLetters++;
                            }
                            else if (Char.IsPunctuation(charr))
                            {
                                counterOfSymbols++;
                            }
                        }

                        writer.WriteLine($"Line{lineCounter}: {line} ({counterOfLetters})({counterOfSymbols})");

                        lineCounter++;
                    }
                }
            }
        }
    }
}
