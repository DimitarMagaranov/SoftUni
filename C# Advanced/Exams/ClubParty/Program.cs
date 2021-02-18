using System;
using System.Collections.Generic;
using System.Linq;

namespace ClubParty
{
    public class Program
    {
        static void Main()
        {
            int hallCapacity = int.Parse(Console.ReadLine());

            List<string> inputData = Console.ReadLine()
                .Split()
                .ToList();

            Stack<string> stack = new Stack<string>();

            List<string> halls = new List<string>();
            Queue<int> peoples = new Queue<int>();


            for (int i = 0; i < inputData.Count; i++)
            {
                stack.Push(inputData[i]);
            }

            Dictionary<string, List<int>> hallsWithPeople = new Dictionary<string, List<int>>();

            while (true)
            {
                bool isInteger = int.TryParse(stack.Peek(), out _);

                if (isInteger)
                {
                    stack.Pop();
                }
                else
                {
                    break;
                }
            }

            while (stack.Any())
            {
                bool isInteger = int.TryParse(stack.Peek(), out _);

                if (isInteger == false)
                {
                    halls.Add(stack.Pop());
                }
                else
                {
                    peoples.Enqueue(int.Parse(stack.Pop()));
                }
            }

            foreach (var item in halls)
            {
                if (hallsWithPeople.ContainsKey(item) == false)
                {
                    hallsWithPeople.Add(item, new List<int>());
                }
            }

            
            foreach (var hall in hallsWithPeople)
            {

                while (peoples.Any() && hall.Value.Sum() + peoples.Peek() <= hallCapacity)
                {
                    hall.Value.Add(peoples.Dequeue());
                }

                if (peoples.Any() && hall.Value.Sum() + peoples.Peek() > hallCapacity)
                {
                    Console.WriteLine($"{hall.Key} -> {string.Join(", ", hall.Value)}");
                }
            }
        }
    }
}
