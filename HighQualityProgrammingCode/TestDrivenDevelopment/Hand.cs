using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public class Hand : IHand
    {
        public IList<ICard> Cards { get; private set; }

        public Hand(IList<ICard> cards)
        {
            if (cards.Count < 5)
            {
                throw new ArgumentException("The number of cards in a hand must be 5.");
            }

            this.Cards = new List<ICard>();
            foreach (var card in cards)
            {
                this.Cards.Add(card);
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder("");
            bool isFirstToAppend = true;

            foreach (var card in this.Cards)
            {
                if (!isFirstToAppend)
                {
                    result.Append(", ");
                }
                isFirstToAppend = false;
                result.Append(card);
            }

            return result.ToString();
        }
    }
}
