using System;

namespace EasterBasket
{
    public class StartUp
    {
        static void Main()
        {
            // Initialize the repository (Basket)
            Basket basket = new Basket("Wood", 20);
            // Initialize entity
            Egg egg = new Egg("Red", 10, "oval");
            // Print Egg
            Console.WriteLine(egg); // You have Red egg with 10 strength, oval shape

            // Add Egg
            basket.AddEgg(egg);
            Console.WriteLine(basket.Count); //1
                                             // Remove Egg
            Console.WriteLine(basket.RemoveEgg("Pink"));  //False

            Egg secondEgg = new Egg("Green", 9, "pointy");

            // Add Egg
            basket.AddEgg(secondEgg);

            // Get strongest egg
            Egg strongestEgg = basket.GetStrongestEgg();
            Console.WriteLine(strongestEgg); // You have Red egg with 10 strength, oval shape
                                             // Get egg
            Egg getEgg = basket.GetEgg("Green"); // You have Green egg with 9 strength, pointy shape
            Console.WriteLine(getEgg);

            Console.WriteLine(basket.Report());
            // Wood basket contains:
            // You have Red egg, with 10 strength and oval shape.
            // You have Green egg, with 9 strength and pointy shape.

        }
    }
}
