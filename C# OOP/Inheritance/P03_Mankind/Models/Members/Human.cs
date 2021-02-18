namespace P03_Mankind.Models
{
    using System.Text;

    public class Human
    {
        private string firstName;
        private string lastName;

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get => this.firstName;
            private set
            {
                Validator.CharIsUpper(value[0], nameof(this.firstName));

                Validator.FirstNameLength(value, nameof(this.firstName));

                this.firstName = value;
            }
        }
        public string LastName
        {
            get => this.lastName;
            private set
            {
                Validator.CharIsUpper(value[0], nameof(this.lastName));

                Validator.LastNameLength(value, nameof(this.lastName));

                this.lastName = value;
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"First Name: {this.FirstName}");
            stringBuilder.AppendLine($"Last Name: {this.LastName}");

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
