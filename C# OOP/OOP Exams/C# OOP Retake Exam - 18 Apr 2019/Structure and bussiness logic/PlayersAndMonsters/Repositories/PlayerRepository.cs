using System;
using System.Collections.Generic;
using System.Linq;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Models.Players.Models;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private List<IPlayer> players = new List<IPlayer>();

        public int Count => this.players.Count;

        public IReadOnlyCollection<IPlayer> Players => this.players;

        public void Add(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }

            if (players.Any(x => x.Username == player.Username))
            {
                throw new ArgumentException($"Player {player.Username} already exists!");
            }

            this.players.Add(player);
        }

        public IPlayer Find(string username)
        {
            IPlayer findedPlayer = (Player)this.players.FirstOrDefault(x => x.Username == username);

            if (findedPlayer != null)
            {
                return findedPlayer;
            }

            return null;
        }

        public bool Remove(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }

            IPlayer playerToRemove = (Player)this.players.FirstOrDefault(x => x.Username == player.Username);

            if (playerToRemove != null)
            {
                this.players.Remove(playerToRemove);
                return true;
            }

            return false;
        }
    }
}
