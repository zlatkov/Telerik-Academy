using System;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            for (int i = 0; i < hand.Cards.Count; ++i)
            {
                for (int j = i + 1; j < hand.Cards.Count; ++j)
                {
                    Console.WriteLine(hand.Cards[i] == hand.Cards[j]);
                    if (hand.Cards[i].ToString() == hand.Cards[j].ToString())
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFourOfAKind(IHand hand)
        {
            foreach (var firstCard in hand.Cards)
            {
                int currentEqualFaces = 0;
                foreach (var secondCard in hand.Cards)
                {
                    if (firstCard.Face == secondCard.Face)
                    {
                        currentEqualFaces++;
                    }
                }

                if (currentEqualFaces == 4)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsFullHouse(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFlush(IHand hand)
        {
            foreach (var firstCard in hand.Cards)
            {
                foreach (var secondCard in hand.Cards)
                {
                    if (firstCard.Suit != secondCard.Suit)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool IsStraight(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsTwoPair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsOnePair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsHighCard(IHand hand)
        {
            throw new NotImplementedException();
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }
    }
}
