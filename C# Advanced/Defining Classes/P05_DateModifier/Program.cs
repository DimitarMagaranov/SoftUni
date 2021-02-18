using System;

namespace P05_DateModifier
{
    public class Program
    {
        public static void Main()
        {
            string date1 = Console.ReadLine();
            string date2 = Console.ReadLine();

            DateModifier dateModifier = new DateModifier();

            Console.WriteLine(dateModifier.GetDifferenseOfDatesInDays(date1, date2));

        }
    }
}
