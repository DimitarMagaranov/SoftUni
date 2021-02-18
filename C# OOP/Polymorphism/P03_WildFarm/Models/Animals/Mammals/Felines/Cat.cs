using P03_WildFarm.Models.Foods;
using System.Collections.Generic;

namespace P03_WildFarm.Models.Animals.Mammals.Felines
{
    public class Cat : Feline
    {
        private const double GainValue = 0.3;

        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(Food food)
        {
            this.BaseEat(food, new List<string>() { nameof(Meat), nameof(Vegetable) }, GainValue);
        }

        public override string ProduceSoundForFood()
        {
            return "Meow";
        }
    }
}
