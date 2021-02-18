using System;

namespace Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstInput = Console.ReadLine().Split();

            string name = $"{firstInput[0]} {firstInput[1]}";
            string adress = firstInput[2];

            Tuple<string, string> firstTuple = new Tuple<string, string>(name, adress);

            string[] secondInput = Console.ReadLine().Split();

            string name2 = secondInput[0];
            int litresOfBeer = int.Parse(secondInput[1]);

            Tuple<string, int> secondTuple = new Tuple<string, int>(name2, litresOfBeer);

            string[] thirdInput = Console.ReadLine().Split();

            int intNum = int.Parse(thirdInput[0]);
            double doubleNum = double.Parse(thirdInput[1]);

            Tuple<int, double> thirdTuple = new Tuple<int, double>(intNum, doubleNum);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}
