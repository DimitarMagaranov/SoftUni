using System;

namespace LAB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            long GetOperationsCount(int n)
            {
                long counter = 0;

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        counter++;
                    }
                }

                return counter;
            }
        }
    }
}
