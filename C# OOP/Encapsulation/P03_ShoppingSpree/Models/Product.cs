using System;
using System.Linq;

namespace P03_ShoppingSpree.Models
{
    public class Product
    {
        private string name;
        private double cost;

        public Product(string name, double cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (value.Any())
                {
                    this.name = value;
                }
                else
                {
                    throw new InvalidOperationException("Name cannot be empty");
                }
            }
        }

        public double Cost
        {
            get => this.cost;
            private set
            {
                if (value >= 0)
                {
                    this.cost = value;
                }
                else
                {
                    throw new InvalidOperationException("Money cannot be negative");
                }
            }
        }
    }
}
