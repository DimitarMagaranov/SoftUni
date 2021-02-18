namespace P03_WildFarm.Models.Foods
{
    public static class FoodFactory
    {
        public static Food Create(params string[] foodArgs)
        {
            string foodName = foodArgs[0];
            int quantity = int.Parse(foodArgs[1]);

            if (foodName == nameof(Vegetable))
            {
                return new Vegetable(quantity);
            }
            else if (foodName == nameof(Fruit))
            {
                return new Fruit(quantity);
            }
            else if (foodName == nameof(Meat))
            {
                return new Meat(quantity);
            }
            else if (foodName == nameof(Seeds))
            {
                return new Seeds(quantity);
            }

            return null;
        }
    }
}
