using System;

using P03_SalesDatabase.IOManagment.Contracts;

namespace P03_SalesDatabase.IOManagment
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
