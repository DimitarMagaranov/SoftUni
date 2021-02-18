namespace P01_DataBase
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main()
        {
            ICollection<int> collection = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Database database = new Database(collection);

            Console.WriteLine();
        }
    }
}
