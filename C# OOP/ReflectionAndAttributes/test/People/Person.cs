using System;
using System.Collections.Generic;
using System.Text;

namespace test.People
{
    public class Person
    {
        private string name;
        protected int age;

        private Person()
        {

        }

        internal Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        protected Person(int age)
        {
            this.age = age;
        }

        public Person(string name)
        {
            this.name = name;
        }

        public string Name { get; set; }

        internal int Age { get; set; }

        private void Eat()
        {
            Console.WriteLine("Eating...");
        }

        protected void Sleep()
        {
            Console.WriteLine("Sleeping...");
        }

        public void Work()
        {
            Console.WriteLine("Working...");
        }
    }
}
