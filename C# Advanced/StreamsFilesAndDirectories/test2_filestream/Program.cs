using System;
using System.IO;
using System.Text;

namespace test2_filestream
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllText("input.txt");
        }
    }
}
