namespace P03_ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using P03_ShoppingSpree.Models;

    public class Program
    {
        static void Main()
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            try
            {
                string[] personWithMoney = Console.ReadLine().Split(new char[] { ';', ' ' });

                foreach (var personToAdd in personWithMoney.Where(x => x != string.Empty))
                {
                    string[] splitedPerson = personToAdd.Split("=");
                    string name = splitedPerson[0];
                    double money = double.Parse(splitedPerson[1]);

                    Person person = new Person(name, money);

                    people.Add(person);
                }

                string[] productWithCost = Console.ReadLine().Split(new char[] { ';', ' '});

                foreach (var productToAdd in productWithCost.Where(x => x != string.Empty))
                {
                    string[] splitedProduct = productToAdd.Split("=");
                    string productName = splitedProduct[0];
                    double cost = double.Parse(splitedProduct[1]);

                    Product product = new Product(productName, cost);
                    products.Add(product);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            while (true)
            {
                string inputLIne = Console.ReadLine();

                if (inputLIne == "END")
                {
                    break;
                }
                else
                {
                    string[] splitedInput = inputLIne.Split();

                    string personName = splitedInput[0];
                    string productName = splitedInput[1];

                    Person person = people.Find(x => x.Name == personName);
                    Product product = products.Find(x => x.Name == productName);

                    person.BuyProduct(product);
                }
            }

            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }
    }
}
