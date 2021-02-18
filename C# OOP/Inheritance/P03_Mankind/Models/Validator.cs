namespace P03_Mankind.Models
{
    using System;
    using System.Linq;

    public static class Validator
    {
        public static void CharIsUpper(char firstLetter, string nameFieldAsString)
        {
            if (char.IsUpper(firstLetter) == false)
            {
                throw new InvalidOperationException(String.Format(Exeptions.UpperCaseExeptionMessage(), nameFieldAsString));
            }
        }

        public static void FirstNameLength(string name, string firstNameFieldAsString)
        {
            if (name.Length < 4)
            {
                throw new InvalidOperationException(String.Format(Exeptions.FirstNameLengthExeptionMessage(), firstNameFieldAsString));
            }
        }

        public static void LastNameLength(string name, string lastNameFieldAsString)
        {
            if (name.Length < 3)
            {
                throw new InvalidOperationException(String.Format(Exeptions.LastNameLengthExeptionMessage(), lastNameFieldAsString));
            }
        }

        public static void IsInvalidFacultyNumberLength(string facultyNumber)
        {
            if (facultyNumber.Length < 5 || facultyNumber.Length > 10)
            {
                throw new InvalidOperationException(Exeptions.FacultyNumberExeptionMessage());
            }
        }

        public static void IsInvalidFacultyNumberSymbols(string facultyNumber)
        {
            if (facultyNumber.All(x => char.IsLetterOrDigit(x)) == false)
            {
                throw new InvalidOperationException(Exeptions.FacultyNumberExeptionMessage());
            }
        }

        public static void IsInvalidWeekSalary(double weekSalary, string weekSalaryFieldAsString)
        {
            if (weekSalary <= 10)
            {
                throw new InvalidOperationException(String.Format(Exeptions.WeekSalaryExeptionMessage(), weekSalaryFieldAsString));
            }
        }

        public static void IsInvalidWorkHoursPerDay(double workHours, string workHoursFeildAsString)
        {
            if (workHours < 1 || workHours > 12)
            {
                throw new InvalidOperationException(String.Format(Exeptions.WorkingHoursExeptionMessage(), workHoursFeildAsString));
            }
        }
    }
}
