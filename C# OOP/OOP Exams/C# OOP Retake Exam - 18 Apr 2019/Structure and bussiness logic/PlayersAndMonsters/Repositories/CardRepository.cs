using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Models.Cards.Models;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Repositories
{
    public class CardRepository : ICardRepository
    {
        private List<ICard> cards = new List<ICard>();

        public int Count => this.cards.Count;

        public IReadOnlyCollection<ICard> Cards => this.cards;

        public void Add(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null!");
            }

            if (this.cards.Any(x => x.Name == card.Name))
            {
                throw new ArgumentException($"Card {card.Name} already exists!");
            }

            this.cards.Add(card);
        }

        public ICard Find(string name)
        {
            ICard findedCard = (Card)this.cards.FirstOrDefault(x => x.Name == name);

            if (findedCard != null)
            {
                return findedCard;
            }

            return null;
        }

        public bool Remove(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null!");
            }

            ICard cardToRemove = this.cards.FirstOrDefault(x => x.Name == card.Name);

            if (cardToRemove != null)
            {
                this.cards.Remove(cardToRemove);
                return true;
            }

            return false;
        }
    }
}
