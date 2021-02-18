using P03_WildFarm.Models.Foods;
using System.Collections.Generic;

namespace P03_WildFarm.Models.Animals.Birds
{
    public class Owl : Bird
    {
        private const double GainValue = 0.25;

        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override void Eat(Food food)
        {
            this.BaseEat(food, new List<string>() { nameof(Meat) }, GainValue);
        }

        public override string ProduceSoundForFood()
        {
            return "Hoot Hoot";
        }
    }
}
