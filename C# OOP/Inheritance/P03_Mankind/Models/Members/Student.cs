﻿namespace P03_Mankind.Models
{
    using System.Text;

    public class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber)
            : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get => this.facultyNumber;
            private set
            {
                Validator.IsInvalidFacultyNumberLength(value);

                Validator.IsInvalidFacultyNumberSymbols(value);

                this.facultyNumber = value;
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(base.ToString());
            stringBuilder.AppendLine($"Faculty number: {this.facultyNumber}");

            return stringBuilder.ToString();
        }
    }
}
