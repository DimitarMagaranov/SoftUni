namespace PlayersAndMonsters.Core.Factories.Models
{
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories;
    using System;
    using System.Linq;
    using System.Reflection;

    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username)
        {
            var playerType = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == type);

            if (playerType == null)
            {
                throw new ArgumentException("Player of this type does not exist.");
            }

            var cardRepository = new CardRepository();

            var player = (IPlayer)Activator.CreateInstance(playerType, cardRepository, username);

            return player;
        }
    }
}
