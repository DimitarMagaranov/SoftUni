namespace P03_WildFarm.Models.Animals.Mammals
{
    public abstract class Feline : Mammal
    {
        private string name;
        private double weight;
        private string livingRegion;

        protected Feline(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
            this.name = name;
            this.weight = weight;
            this.livingRegion = livingRegion;
        }

        protected Feline(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion)
        {
            this.Breed = breed;
        }

        public string Breed { get; private set; }

        public override string ToString()
        {
            return $"{base.ToString()}{this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
