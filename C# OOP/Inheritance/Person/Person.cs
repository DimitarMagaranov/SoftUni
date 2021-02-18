namespace Person
{
    public abstract class Person
    {
        private int age;

        public Person(string name, int age)
        {
            this.Age = age;
            this.Name = name;
        }

        public string Name { get; private set; }

        public virtual int Age
        {
            get => this.age;
            protected set
            {
                if (value > 0)
                {
                    this.age = value;
                }
            }
        }

        public override string ToString()
        {
            return $"Name: {this.Name}, Age: {this.age}";
        }
    }
}
