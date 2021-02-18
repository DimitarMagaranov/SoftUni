using System;
using System.Text.RegularExpressions;

namespace P03_Telephony
{
    public class Program
    {
        public static void Main()
        {
            string[] phoneNumbersToCall = Console.ReadLine().Split();
            string[] sitesToVisit = Console.ReadLine().Split();

            Smartphone smartphone = new Smartphone();
            StationeryPhone stationeryPhone = new StationeryPhone();

            foreach (var number in phoneNumbersToCall)
            {
                if (Regex.IsMatch(number, "^\\d+$"))
                {
                    if (number.Length == 7)
                    {
                        Console.WriteLine(stationeryPhone.Calling(number));
                    }
                    else
                    {
                        Console.WriteLine(smartphone.Calling(number));
                    }
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
                
            }

            foreach (var site in sitesToVisit)
            {
                if (Regex.IsMatch(site, "\\d") == false)
                {
                    Console.WriteLine(smartphone.Browsing(site));
                }
                else
                {
                    Console.WriteLine("Invalid URL!");
                }
            }
        }
    }
}
