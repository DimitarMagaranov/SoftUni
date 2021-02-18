using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterBasket
{
    public class Basket
    {
        private List<Egg> data;

        public Basket(string material, int capacity)
        {
            this.Material = material;
            this.Capacity = capacity;
            this.data = new List<Egg>();
        }

        public string Material { get; private set; }

        public int Capacity { get; private set; }

        public int Count => this.data.Count();

        public void AddEgg(Egg egg)
        {

            if (this.data.Count < this.Capacity && this.data.Any(x => x.Color == egg.Color) == false && this.data.Any(x => x.Strength == egg.Strength) == false)
            {
                this.data.Add(egg);
            }
        }

        public bool RemoveEgg(string color)
        {
            Egg egg = this.data.FirstOrDefault(x => x.Color == color);

            if (egg != null)
            {
                this.data.Remove(egg);
                return true;
            }

            return false;
        }

        public Egg GetStrongestEgg()
        {
            List<Egg> sortedEggs = this.data.OrderByDescending(x => x.Strength).ToList();

            return sortedEggs.First();
        }

        public Egg GetEgg(string color)
        {
            Egg egg = this.data.FirstOrDefault(x => x.Color == color);

            return egg;
        }

        public string Report()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"{this.Material} basket contains:");

            foreach (var egg in this.data)
            {
                stringBuilder.AppendLine(egg.ToString());
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
