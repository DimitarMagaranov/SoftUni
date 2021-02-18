namespace P03_Mankind.Models
{
    public static class Exeptions
    {
        public static string UpperCaseExeptionMessage() => "Expected upper case letter! Argument: {0}";
        public static string FirstNameLengthExeptionMessage() => "Expected length at least 4 symbols! Argument: {0}";
        public static string LastNameLengthExeptionMessage() => "Expected length at least 3 symbols! Argument: {0}";
        public static string FacultyNumberExeptionMessage() => "Invalid faculty number!";
        public static string WeekSalaryExeptionMessage() => "Expected value mismatch! Argument: {0}";
        public static string WorkingHoursExeptionMessage() => "Expected value mismatch! Argument: {0}";
    }
}
