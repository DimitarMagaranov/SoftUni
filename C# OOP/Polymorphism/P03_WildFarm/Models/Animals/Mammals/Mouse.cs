using P03_WildFarm.Models.Foods;
using System.Collections.Generic;

namespace P03_WildFarm.Models.Animals.Mammals
{
    public class Mouse : Mammal
    {
        private const double GainValue = 0.1;

        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override void Eat(Food food)
        {
            this.BaseEat(food, new List<string>() { nameof(Fruit), nameof(Vegetable) }, GainValue);
        }

        public override string ProduceSoundForFood()
        {
            return "Squeak";
        }

        public override string ToString()
        {
            return $"{base.ToString()}{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
