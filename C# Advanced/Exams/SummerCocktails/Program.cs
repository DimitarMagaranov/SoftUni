using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SummerCocktails
{
    public class Program
    {
        static void Main()
        {
            Queue<int> ingredients = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> freshnessLevels = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            Dictionary<string, int> cocktailsToCheck = new Dictionary<string, int>();
            Dictionary<string, int> cocktails = new Dictionary<string, int>();

            cocktailsToCheck.Add("Mimosa", 150);
            cocktailsToCheck.Add("Daiquiri", 250);
            cocktailsToCheck.Add("Sunshine", 300);
            cocktailsToCheck.Add("Mojito", 400);

            cocktails.Add("Mimosa", 0);
            cocktails.Add("Daiquiri", 0);
            cocktails.Add("Sunshine", 0);
            cocktails.Add("Mojito", 0);

            while (ingredients.Any() && freshnessLevels.Any())
            {
                int ingredient = ingredients.Peek();
                int freshnessLevel = freshnessLevels.Peek();

                int result = ingredient * freshnessLevel;

                if (ingredient == 0)
                {
                    ingredients.Dequeue();
                    continue;
                }
                
                foreach (var cocktail in cocktailsToCheck.Where(x => x.Value == result))
                {
                    cocktails[cocktail.Key] += 1;
                    ingredients.Dequeue();
                    freshnessLevels.Pop();
                }

                if (cocktailsToCheck.Any(x => x.Value == result) == false)
                {
                    freshnessLevels.Pop();
                    int temp = ingredients.Dequeue() + 5;
                    ingredients.Enqueue(temp);
                }
            }

            Console.WriteLine(Print(cocktails, ingredients, freshnessLevels));
        }

        static string Print(Dictionary<string, int> cocktails, Queue<int> ingredients, Stack<int> freshnessValues)
        {
            bool isSucsessed = true;

            if (cocktails.Any(x => x.Value == 0))
            {
                isSucsessed = false;
            }

            StringBuilder result = new StringBuilder();

            if (isSucsessed)
            {
                result.AppendLine("It's party time! The cocktails are ready!");
            }
            else
            {
                result.AppendLine("What a pity! You didn't manage to prepare all cocktails.");
            }

            if (ingredients.Any())
            {
                result.AppendLine($"Ingredients left: {ingredients.Sum().ToString()}");
            }

            foreach (var cocktail in cocktails.Where(x => x.Value > 0).OrderBy(x => x.Key))
            {
                result.AppendLine($" # {cocktail.Key} --> {cocktail.Value}");
            }

            return result.ToString();
        }
    }
}
