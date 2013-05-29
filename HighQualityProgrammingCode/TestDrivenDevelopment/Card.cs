using System;

namespace Poker
{
    public class Card : ICard
    {
        public CardFace Face { get; private set; }
        public CardSuit Suit { get; private set; }

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public override string ToString()
        {
            string face = String.Empty;
            int faceValue = (int)this.Face;
            if (faceValue < 10)
            {
                face = faceValue.ToString();
            }
            else
            {
                face = this.Face.ToString();
            }

            char suitSymbol;
            switch (this.Suit)
            {
                case CardSuit.Clubs: suitSymbol = '♣'; break;
                case CardSuit.Diamonds: suitSymbol = '♦'; break;
                case CardSuit.Hearts: suitSymbol = '♥'; break;
                case CardSuit.Spades: suitSymbol = '♠'; break;
                default: throw new ArgumentException("The card suit: " + this.Suit + " is not valid.");
            }

            return String.Format("{0}{1}", face, suitSymbol);
        }
    }
}
