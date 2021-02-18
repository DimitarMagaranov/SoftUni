using System;
using System.Collections.Generic;
using System.Text;

namespace EasterBasket
{
    public class Egg
    {
        public Egg(string color, int strength, string shape)
        {
            this.Color = color;
            this.Strength = strength;
            this.Shape = shape;
        }

        public string Color { get; private set; }

        public int Strength { get; private set; }

        public string Shape { get; private set; }

        public override string ToString()
        {
            return $"You have {this.Color} egg, with {this.Strength} strength and {this.Shape} shape.";
        }
    }
}
