using System.Collections.Generic;
using P03_WildFarm.Models.Foods;

namespace P03_WildFarm.Models.Animals.Mammals
{
    public class Dog : Mammal
    {
        private const double GainValue = 0.4;

        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override void Eat(Food food)
        {
            this.BaseEat(food, new List<string>() { nameof(Meat) }, GainValue);
        }

        public override string ProduceSoundForFood()
        {
            return "Woof!";
        }

        public override string ToString()
        {
            return $"{base.ToString()}{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
