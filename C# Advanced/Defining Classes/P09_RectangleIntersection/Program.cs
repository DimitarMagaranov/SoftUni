using System;
using System.Collections.Generic;
using System.Linq;

namespace P09_RectangleIntersection
{
    public class Program
    {
        public static void Main()
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            ChecIntersection(input);
        }

        private static void ChecIntersection(int[] input)
        {
            int countOfRectangles = input[0];
            int countOfIntersectionChecks = input[1];

            List<Rectangle> rectangles = new List<Rectangle>();

            for (int i = 0; i < countOfRectangles; i++)
            {
                Rectangle rectangle = GetRectangle();

                if (rectangles.Contains(rectangle) == false)
                {
                    rectangles.Add(rectangle);
                }
            }

            for (int i = 0; i < countOfIntersectionChecks; i++)
            {
                string[] idsToCheck = Console.ReadLine().Split();

                string firstId = idsToCheck[0];
                string secondId = idsToCheck[1];


                foreach (var firstRect in rectangles.Where(r => r.Id == firstId))
                {
                    Rectangle firstRectToCheck = firstRect;
                    foreach (var secondRect in rectangles.Where(r => r.Id == secondId))
                    {
                        Rectangle secondRectToCheck = secondRect;

                        Console.WriteLine(firstRectToCheck.ChecIntersect(secondRectToCheck));
                    }
                }
            }
        }
        
        private static Rectangle GetRectangle()
        {
            string[] parameters = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string id = parameters[0];
            int width = int.Parse(parameters[1]);
            int height = int.Parse(parameters[2]);
            int coordinateXtopLeft = int.Parse(parameters[3]);
            int coordinateYtopLeft = int.Parse(parameters[4]);

            Rectangle rectangle = new Rectangle(id, width, height, coordinateXtopLeft, coordinateYtopLeft);

            return rectangle;
        }
    }
}
