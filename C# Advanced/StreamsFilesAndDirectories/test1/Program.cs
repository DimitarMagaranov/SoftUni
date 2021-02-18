using System;
using System.IO;

namespace test1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            using (var reader = new StreamReader(@"Resources\01. Odd Lines\mitko.txt"))
            {
                while (true)
                {
                    char[] buffer = new char[4];

                    var total = reader.Read(buffer, 0, buffer.Length);

                    for (int i = 0; i < total; i++)
                    {
                        Console.Write(buffer[i]);
                    }

                    if (total == 0)
                    {
                        break;
                    }
                }
            }
        }
    }
}
