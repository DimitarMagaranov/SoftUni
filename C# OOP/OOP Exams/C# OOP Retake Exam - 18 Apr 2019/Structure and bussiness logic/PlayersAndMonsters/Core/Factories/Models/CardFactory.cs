using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Cards.Contracts;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PlayersAndMonsters.Core.Factories.Models
{
    public class CardFactory : ICardFactory
    {
        public ICard CreateCard(string type, string name)
        {
            var cardType = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == type + "Card");

            if (cardType == null)
            {
                throw new ArgumentException("Card of this type does not exist.");
            }

            var card = (ICard)Activator.CreateInstance(cardType, name);

            return card;
        }
    }
}
