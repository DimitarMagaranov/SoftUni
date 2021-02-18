using System;
using System.Collections.Generic;
using System.Text;

namespace P10_CarSalesman
{
    public class Car
    {
        public Car(string model, Engine engine)
            :this(model, engine, 0, "n/a")
        {

        }

        public Car(string model, Engine engine, string color)
            :this(model, engine, 0, color)
        {

        }

        public Car(string model, Engine engine, int weight)
            :this(model, engine, weight, "n/a")
        {

        }

        public Car(string model, Engine engine, int weight, string color)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = weight;
            this.Color = color;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }



        public override string ToString()
        {
            string weight = string.Empty;
            string displacement = string.Empty;

            if (this.Weight == 0)
            {
                weight = "n/a";
            }
            else
            {
                weight = this.Weight.ToString();
            }

            if (this.Engine.Displacement == 0)
            {
                displacement = "n/a";
            }
            else
            {
                displacement = this.Engine.Displacement.ToString();
            }
            
            return $"{this.Model}:" + Environment.NewLine +
                $"  {this.Engine.Model}:" + Environment.NewLine +
                $"    Power: {this.Engine.Power}" + Environment.NewLine +
                $"    Displacement: {displacement}" + Environment.NewLine +
                $"    Efficiency: {this.Engine.Efficiency}" + Environment.NewLine +
                $"  Weight: {weight}" + Environment.NewLine +
                $"  Color: {this.Color}";
        }
    }
}
