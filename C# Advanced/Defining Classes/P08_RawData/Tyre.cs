using System;
using System.Collections.Generic;
using System.Text;

namespace P08_RawData
{
    public class Tyre
    {
        public int Age { get; set; }
        public double Presure { get; set; }

        public Tyre(double presure, int age)
        {
            this.Presure = presure;
            this.Age = age;
        }
    }
}
