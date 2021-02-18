using System;
using System.Collections.Generic;
using System.Text;

namespace P11_PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string name)
        {
            this.Name = name;
            this.BudgesCount = 0;
            this.Pokemons = new List<Pokemon>();
        }

        public string Name { get; set; }
        public int BudgesCount { get; set; }
        public List<Pokemon> Pokemons { get; set; }

        public override string ToString()
        {
            return $"{this.Name} {this.BudgesCount} {this.Pokemons.Count}";
        }
    }
}
