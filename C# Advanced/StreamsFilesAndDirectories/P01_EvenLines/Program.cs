using System;
using System.Collections.Generic;
using System.IO;

namespace P01_EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader(@"..\..\..\text.txt"))
            {
                while (true)
                {
                    string line = reader.ReadLine();

                    if (line == null)
                    {
                        break;
                    }

                    char[] lineToCharAraay = line.ToCharArray();

                    for (int i = 0; i < lineToCharAraay.Length; i++) //{"-", ",", ".", "!", "?"
                    {
                        if (lineToCharAraay[i] == '-'
                            || lineToCharAraay[i] == ','
                            || lineToCharAraay[i] == '.'
                            || lineToCharAraay[i] == '!'
                            || lineToCharAraay[i] == '?')
                        {
                            lineToCharAraay[i] = '@';
                        }
                    }

                    string charArrayToString = new string(lineToCharAraay);

                    string[] array = charArrayToString.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    Stack<string> stack = new Stack<string>(array);

                    Console.WriteLine(string.Join(' ', stack));
                }
            }


        }
    }
}
