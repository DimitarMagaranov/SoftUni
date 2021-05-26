using System;
using Wintellect.PowerCollections;

namespace _04.CookiesProblem
{
    public class CookiesProblem
    {
        public int Solve(int k, int[] cookies)
        {
            var priorityQueue = new OrderedBag<int>();

            foreach (var cookie in cookies)
            {
                priorityQueue.Add(cookie);
            }

            var operationsCounter = 0;

            var currentMinSweetness = priorityQueue.GetFirst();

            while (currentMinSweetness < k && priorityQueue.Count > 1)
            {
                var leastSweetCookie = priorityQueue.RemoveFirst();
                var secondLeastSweetCookie = priorityQueue.RemoveFirst();

                var combined = leastSweetCookie + (2 * secondLeastSweetCookie);
                priorityQueue.Add(combined);

                currentMinSweetness = priorityQueue.GetFirst();
                operationsCounter++;
            }

            return currentMinSweetness < k ? -1 : operationsCounter;
        }
    }
}
