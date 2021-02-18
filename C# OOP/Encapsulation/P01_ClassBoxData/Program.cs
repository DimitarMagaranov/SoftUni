namespace P01_ClassBoxData
{
    using System;

    public class Program
    {
        static void Main()
        {
            try
            {
                double length = double.Parse(Console.ReadLine());
                double width = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());

                Box box = new Box(length, width, height);

                Console.WriteLine(box.SurfaceArea());
                Console.WriteLine(box.LaterealSurfaceArea());
                Console.WriteLine(box.Volume());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
