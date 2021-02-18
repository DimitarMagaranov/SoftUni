using System;
using System.Collections.Generic;
using System.Text;

namespace P05_DateModifier
{
    public class DateModifier
    {
        public int GetDifferenseOfDatesInDays(string date1, string date2)
        {
            string[] splittedDate1 = date1.Split();
            int year1 = int.Parse(splittedDate1[0]);
            int month1 = int.Parse(splittedDate1[1]);
            int day1 = int.Parse(splittedDate1[2]);

            DateTime dateTime1 = new DateTime(year1, month1, day1);

            string[] splittedDate2 = date2.Split();
            int year2 = int.Parse(splittedDate2[0]);
            int month2 = int.Parse(splittedDate2[1]);
            int day2 = int.Parse(splittedDate2[2]);

            DateTime dateTime2 = new DateTime(year2, month2, day2);

            int days = (dateTime1 - dateTime2).Days;

            if (days < 0)
            {
                days = days * -1;
            }

            return days;
        }
    }
}
