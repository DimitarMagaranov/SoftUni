using System;
using System.Collections.Generic;
using System.Linq;

namespace P11_PokemonTrainer
{
    public class Program
    {
        public static void Main()
        {
            List<Trainer> trainers = new List<Trainer>();

            while (true)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (tokens[0] == "Tournament")
                {
                    break;
                }

                string nameOfTrainer = tokens[0];
                string nameOfPokemon = tokens[1];
                string elementOfPokemon = tokens[2];
                int healthOfPokemon = int.Parse(tokens[3]);

                Pokemon pokemon = new Pokemon(nameOfPokemon, elementOfPokemon, healthOfPokemon);

                Trainer trainer = trainers.FirstOrDefault(t => t.Name == nameOfTrainer);

                if (trainer == null)
                {
                    trainer = new Trainer(nameOfTrainer);
                    trainers.Add(trainer);
                }

                trainer.Pokemons.Add(pokemon);
            }

            while (true)
            {
                string element = Console.ReadLine();

                if (element == "End")
                {
                    break;
                }

                foreach (var trainer in trainers)
                {
                    if (trainer.Pokemons.Any(p => p.Element == element))
                    {
                        trainer.BudgesCount++;
                    }
                    else
                    {
                        ReduceHealth(trainer.Pokemons);
                    }
                }
            }
            
            foreach (var trainer in trainers.OrderByDescending(t => t.BudgesCount))
            {
                Console.WriteLine(trainer);
            }
        }

        static void ReduceHealth(List<Pokemon> pokemons)
        {
            for (int i = 0; i < pokemons.Count; i++)
            {
                Pokemon pokemon = pokemons[i];

                pokemon.Health -= 10;

                if (pokemon.Health <= 0)
                {
                    pokemons.Remove(pokemon);
                    i--;
                }
            }
        }
    }
}
