using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_GenericBoxOfString
{
    public class Program
    {
        static void Main()
        {
            int countOfElements = int.Parse(Console.ReadLine());

            Box<double> box = new Box<double>();

            for (int i = 0; i < countOfElements; i++)
            {
                box.Add(double.Parse(Console.ReadLine()));
            }

            double elementToCompare = double.Parse(Console.ReadLine());

            Console.WriteLine(GetCountOfGreaterElements(box.Data, elementToCompare));
        }

        public static int GetCountOfGreaterElements<T>(List<T> elements, T element) where T : IComparable
        {
            int count = 0;

            foreach (var item in elements)
            {
                if (item.CompareTo(element) > 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
