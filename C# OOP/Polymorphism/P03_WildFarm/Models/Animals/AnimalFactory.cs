using P03_WildFarm.Models.Animals.Birds;
using P03_WildFarm.Models.Animals.Mammals;
using P03_WildFarm.Models.Animals.Mammals.Felines;

namespace P03_WildFarm.Models.Animals
{
    public static class AnimalFactory
    {
        public static Animal Create(params string[] animalArgs)
        {
            string animalType = animalArgs[0];
            string name = animalArgs[1];
            double weight = double.Parse(animalArgs[2]);

            if (animalType == nameof(Hen))
            {
                double wingSize = double.Parse(animalArgs[3]);

                return new Hen(name, weight, wingSize);
            }
            else if (animalType == nameof(Owl))
            {
                double wingSize = double.Parse(animalArgs[3]);

                return new Owl(name, weight, wingSize);
            }
            else if (animalType == nameof(Mouse))
            {
                string livingRegion = animalArgs[3];

                return new Mouse(name, weight, livingRegion);
            }
            else if (animalType == nameof(Dog))
            {
                string livingRegion = animalArgs[3];

                return new Dog(name, weight, livingRegion);
            }
            else if (animalType == nameof(Cat))
            {
                string livingRegion = animalArgs[3];
                string breed = animalArgs[4];

                return new Cat(name, weight, livingRegion, breed);
            }
            else if (animalType == nameof(Tiger))
            {
                string livingRegion = animalArgs[3];
                string breed = animalArgs[4];

                return new Tiger(name, weight, livingRegion, breed);
            }

            return null;
        }
    }
}
