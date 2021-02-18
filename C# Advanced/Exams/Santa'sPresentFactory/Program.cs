using System;
using System.Collections.Generic;
using System.Linq;

namespace Santa_sPresentFactory
{
    public class Program
    {
        static void Main()
        {
            Stack<int> boxOfMaterials = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Queue<int> magicValues = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            Dictionary<string, int> presents = new Dictionary<string, int>();

            presents.Add("Doll", 150);
            presents.Add("Wooden train", 250);
            presents.Add("Teddy bear", 300);
            presents.Add("Bicycle", 400);

            Dictionary<string, int> craftPresents = new Dictionary<string, int>();

            craftPresents.Add("Doll", 0);
            craftPresents.Add("Wooden train", 0);
            craftPresents.Add("Teddy bear", 0);
            craftPresents.Add("Bicycle", 0);

            while (boxOfMaterials.Any() && magicValues.Any())
            {
                int material = boxOfMaterials.Peek();
                int magicValue = magicValues.Peek();

                int totalMagicValue = material * magicValue;

                if (presents.Any(x => x.Value == totalMagicValue))
                {
                    foreach (var mat in presents.Where(x => x.Value == totalMagicValue))
                    {
                        craftPresents[mat.Key]++;
                    }

                    boxOfMaterials.Pop();
                    magicValues.Dequeue();
                }
                else
                {
                    if (totalMagicValue < 0)
                    {
                        int newMaterial = material + magicValue;
                        boxOfMaterials.Pop();
                        magicValues.Dequeue();
                        boxOfMaterials.Push(newMaterial);
                    }
                    else if (totalMagicValue > 0)
                    {
                        magicValues.Dequeue();
                        boxOfMaterials.Push(boxOfMaterials.Pop() + 15);
                    }
                    else
                    {
                        if (magicValue == 0)
                        {
                            magicValues.Dequeue();
                        }

                        if(material == 0)
                        {
                            boxOfMaterials.Pop();
                        }

                        continue;
                    }
                }
            }

            if (craftPresents["Doll"] > 0 && craftPresents["Wooden train"] > 0
                    || craftPresents["Teddy bear"] > 0 && craftPresents["Bicycle"] > 0)
            {
                Console.WriteLine("The presents are crafted! Merry Christmas!");
            }
            else
            {
                Console.WriteLine("No presents this Christmas!");
            }

            if (boxOfMaterials.Any())
            {
                Console.WriteLine($"Materials left: {string.Join(", ", boxOfMaterials)}");
            }

            if (magicValues.Any())
            {
                Console.WriteLine($"Magic left: {string.Join(", ", magicValues)}");
            }

            foreach (var present in craftPresents.Where(x => x.Value > 0).OrderBy(x => x.Key))
            {
                Console.WriteLine($"{present.Key}: {present.Value}");
            }
        }
    }
}
