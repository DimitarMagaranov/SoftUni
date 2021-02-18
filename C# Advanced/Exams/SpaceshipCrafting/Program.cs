using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceshipCrafting
{
    public class Program
    {
        static void Main()
        {
            Queue<int> chemicalLiquids = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> physicalItems = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            Dictionary<string, int> advancedMaterials = new Dictionary<string, int>();

            Dictionary<string, int> materialsToUse = new Dictionary<string, int>();

            advancedMaterials.Add("Glass", 25);
            advancedMaterials.Add("Aluminium", 50);
            advancedMaterials.Add("Lithium", 75);
            advancedMaterials.Add("Carbon fiber", 100);

            materialsToUse.Add("Glass", 0);
            materialsToUse.Add("Aluminium", 0);
            materialsToUse.Add("Lithium", 0);
            materialsToUse.Add("Carbon fiber", 0);

            while (chemicalLiquids.Any() && physicalItems.Any())
            {
                int liquid = chemicalLiquids.Peek();
                int item = physicalItems.Peek();
                int materialToCheck = liquid + item;


                foreach (var mat in advancedMaterials.Where(x => x.Value == materialToCheck))
                {
                    materialsToUse[mat.Key] += 1;

                    chemicalLiquids.Dequeue();
                    physicalItems.Pop();
                }

                if (advancedMaterials.Any(x => x.Value == materialToCheck) == false)
                {
                    chemicalLiquids.Dequeue();
                    int increaseValue = physicalItems.Pop() + 3;
                    physicalItems.Push(increaseValue);
                }
            }

            Console.WriteLine(Print(materialsToUse, chemicalLiquids, physicalItems));
        }

        public static string Print(Dictionary<string, int> materialsToUse, Queue<int> chemicalLiquids, Stack<int> physicalItems)
        {
            StringBuilder stringBuilder = new StringBuilder();

            bool isSucsesfull = true;

            if (materialsToUse.Any(x => x.Value == 0))
            {
                isSucsesfull = false;
            }

            if (isSucsesfull)
            {
                stringBuilder.AppendLine("Wohoo! You succeeded in building the spaceship!");
            }
            else
            {
                stringBuilder.AppendLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }

            if (chemicalLiquids.Any() == false)
            {
                stringBuilder.AppendLine($"Liquids left: none");
            }
            else
            {
                stringBuilder.AppendLine($"Liquids left: {string.Join(", ", chemicalLiquids.ToArray())}");
            }

            if (physicalItems.Any() == false)
            {
                stringBuilder.AppendLine($"Physical items left: none");
            }
            else
            {
                stringBuilder.AppendLine($"Physical items left: {string.Join(", ", physicalItems.ToArray())}");
            }

            foreach (var item in materialsToUse.OrderBy(x => x.Key))
            {
                stringBuilder.AppendLine($"{item.Key}: {item.Value}");
            }

            return stringBuilder.ToString();
        }
    }
}
