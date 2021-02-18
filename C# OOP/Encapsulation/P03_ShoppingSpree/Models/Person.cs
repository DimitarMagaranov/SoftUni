using System;
using System.Collections.Generic;
using System.Linq;

namespace P03_ShoppingSpree.Models
{
    public class Person
    {
        private string name;
        private double money;
        private List<Product> bag;

        public Person(string name, double money)
        {
            this.Name = name;
            this.Money = money;
            this.bag = new List<Product>();
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

        public double Money
        {
            get => this.money;
            private set
            {
                if (value >= 0)
                {
                    this.money = value;
                }
                else
                {
                    throw new InvalidOperationException("Money cannot be negative");
                }
            }
        }

        public void BuyProduct(Product product)
        {
            if (this.money >= product.Cost)
            {
                bag.Add(product);
                this.money -= product.Cost;
                Console.WriteLine($"{this.name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{this.name} can't afford {product.Name}");
            }
        }

        public override string ToString()
        {
            string personToString = $"{this.name} - ";

            if (this.bag.Any())
            {
                List<string> nameOfProducts = new List<string>();

                foreach (var product in this.bag)
                {
                    nameOfProducts.Add(product.Name);
                }

                personToString += $"{string.Join(", ", nameOfProducts)}";
            }
            else
            {
                personToString += "Nothing bought";
            }

            return personToString;
        }
    }
}
