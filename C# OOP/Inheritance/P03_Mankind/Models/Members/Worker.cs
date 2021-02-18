namespace P03_Mankind.Models
{
    using System.Text;

    public class Worker : Human
    {
        private double weekSalary;
        private double workHoursPerDay;

        public Worker(string firstName, string lastName, double weekSalary, double workingHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workingHoursPerDay;
        }

        public double WeekSalary
        {
            get => this.weekSalary;
            private set
            {
                Validator.IsInvalidWeekSalary(value, nameof(this.weekSalary));

                this.weekSalary = value;
            }
        }

        public double WorkHoursPerDay
        {
            get => this.workHoursPerDay;
            private set
            {
                Validator.IsInvalidWorkHoursPerDay(value, nameof(this.workHoursPerDay));

                this.workHoursPerDay = value;
            }
        }

        public double GetSalaryPerHour()
        {
            double weekWorkingHours = 5 * this.workHoursPerDay;
            double result = this.weekSalary / weekWorkingHours;

            return result;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(base.ToString());
            stringBuilder.AppendLine($"Week Salary: {this.weekSalary:f2}");
            stringBuilder.AppendLine($"Hours per day: {this.workHoursPerDay:f2}");
            stringBuilder.AppendLine($"Salary per hour: {GetSalaryPerHour():f2}");

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
