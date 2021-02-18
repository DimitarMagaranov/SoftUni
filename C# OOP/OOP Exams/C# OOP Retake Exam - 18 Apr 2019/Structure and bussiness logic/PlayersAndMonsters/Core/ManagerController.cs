namespace PlayersAndMonsters.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Models.BattleFields.Models;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Cards.Models;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Models.Players.Models;
    using PlayersAndMonsters.Repositories;
    using PlayersAndMonsters.Repositories.Contracts;

    public class ManagerController : IManagerController
    {
        private ICardRepository cardRepository;
        private IPlayerRepository playerRepository;
        private IBattleField battleField;
        private ICardFactory cardFactory;
        private IPlayerFactory playerFactory;

        public ManagerController(ICardRepository cardRepository,
                                 IPlayerRepository playerRepository,
                                 IBattleField battleField,
                                 ICardFactory cardFactory,
                                 IPlayerFactory playerFactory)
        {
            this.cardRepository = cardRepository;
            this.playerRepository = playerRepository;
            this.battleField = battleField;
            this.cardFactory = cardFactory;
            this.playerFactory = playerFactory;
        }

        public string AddPlayer(string type, string username)
        {
            var player = this.playerFactory.CreatePlayer(type, username);

            this.playerRepository.Add(player);

            return $"Successfully added player of type {type} with username: {username}";
        }

        public string AddCard(string type, string name)
        {
            var card = this.cardFactory.CreateCard(type, name);

            this.cardRepository.Add(card);

            return $"Successfully added card of type {type}Card with name: {name}";
        }

        public string AddPlayerCard(string username, string cardName)
        {
            var player = this.playerRepository.Find(username);

            var card = this.cardRepository.Find(cardName);

            player.CardRepository.Add(card);

            return $"Successfully added card: {cardName} to user: {username}";
        }

        public string Fight(string attackUser, string enemyUser)
        {
            IPlayer attacker = this.playerRepository.Find(attackUser);
            IPlayer enemy = this.playerRepository.Find(enemyUser);

            this.battleField.Fight(attacker, enemy);

            return $"Attack user health {attacker.Health} - Enemy user health {enemy.Health}";
        }

        public string Report()
        {
            StringBuilder stringBuilder = new StringBuilder();

            var players = this.playerRepository.Players;

            foreach (var player in players)
            {
                stringBuilder.AppendLine($"Username: {player.Username} - Health: {player.Health} – Cards {player.CardRepository.Count}");

                foreach (var card in player.CardRepository.Cards)
                {
                    stringBuilder.AppendLine($"Card: {card.Name} - Damage: {card.DamagePoints}");
                }

                stringBuilder.AppendLine("###");
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
