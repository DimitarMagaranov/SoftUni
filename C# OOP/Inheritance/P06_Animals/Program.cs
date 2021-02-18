using System;
using System.Linq;
using P06_Animals.Models;

namespace P06_Animals
{
    public class Program
    {
        static void Main()
        {
            while (true)
            {
                string type = Console.ReadLine();

                if (type == "Beast!")
                {
                    break;
                }

                try
                {
                    string[] animalInfo = Console.ReadLine().Split();
                    string animalName = animalInfo[0];
                    int animalAge = int.Parse(animalInfo[1]);
                    string animalGender = animalInfo[2];
                    switch (type.ToLower())
                    {
                        case "cat":
                            Cat cat = new Cat(animalName, animalAge, animalGender);
                            Console.WriteLine(cat);
                            break;
                        case "dog":
                            Dog dog = new Dog(animalName, animalAge, animalGender);
                            Console.WriteLine(dog);
                            break;
                        case "frog":
                            Frog frog = new Frog(animalName, animalAge, animalGender);
                            Console.WriteLine(frog);
                            break;
                        case "kitten":
                            Kitten kitten = new Kitten(animalName, animalAge);
                            Console.WriteLine(kitten);
                            break;
                        case "tomcat":
                            Tomcat tomcat = new Tomcat(animalName, animalAge);
                            Console.WriteLine(tomcat);
                            break;
                        default:
                            break;
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}

