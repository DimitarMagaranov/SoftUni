﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P10_CarSalesman
{
    public class Engine
    {
        public Engine(string model, int power)
            : this(model, power, 0, "n/a")
        {

        }

        public Engine(string model, int power, int displacement)
            : this(model, power, displacement, "n/a")
        {

        }

        public Engine(string model, int power, string efficiency)
            : this(model, power, 0, efficiency)
        {

        }

        public Engine(string model, int power, int displacement, string efficiency)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }


        public string Model { get; set; }
        public int Power { get; set; }
        public int Displacement { get; set; }
        public string Efficiency { get; set; }
    }
}
