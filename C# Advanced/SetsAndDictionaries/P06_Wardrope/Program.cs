using System;
using System.Collections.Generic;

namespace P06_Wardrope
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> dictionary = new Dictionary<string, Dictionary<string, int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] inputLine = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string color = inputLine[0];
                string[] clothes = inputLine[1].Split(',');

                if (dictionary.ContainsKey(color) == false)
                {
                    dictionary.Add(color, new Dictionary<string, int>());

                    foreach (var item in clothes)
                    {
                        if (dictionary[color].ContainsKey(item) == false)
                        {
                            dictionary[color].Add(item, 1);
                        }
                        else
                        {
                            dictionary[color][item]++;
                        }
                    }
                }
                else
                {
                    foreach (var item in clothes)
                    {
                        if (dictionary[color].ContainsKey(item) == false)
                        {
                            dictionary[color].Add(item, 1);
                        }
                        else
                        {
                            dictionary[color][item]++;
                        }
                    }
                }
            }

            string[] searched = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string searchedColor = searched[0];
            string searchedItem = searched[1];

            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key} clothes:");

                foreach (var clothes in item.Value)
                {
                    if (item.Key == searchedColor && clothes.Key == searchedItem)
                    {
                        Console.WriteLine($"* {clothes.Key} - {clothes.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {clothes.Key} - {clothes.Value}");
                    }
                }
            }
        }
    }
}
