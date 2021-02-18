using System;
using System.Collections.Generic;
using System.Text;

namespace P08_RawData
{
    public class Car
    {
        public Car(string model, Engine engine, Cargo cargo, Tyre[] tyres)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tyres = tyres;
        }
        
        public string Model { get; set; }

        public Engine Engine { get; set; }

        public Cargo Cargo { get; set; }

        public Tyre[] Tyres { get; set; } = new Tyre[4];
    }
}
