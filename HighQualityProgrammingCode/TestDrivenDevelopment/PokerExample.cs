﻿using System;
using System.Collections.Generic;

namespace Poker
{
    class PokerExample
    {
        static void Main()
        {
            ICard card = new Card(CardFace.Ace, CardSuit.Clubs);
            Console.WriteLine(card);

            var cards = new List<ICard>() {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds)
            };

            IHand hand = new Hand(cards);
            Console.WriteLine(hand);

            //IPokerHandsChecker checker = new PokerHandsChecker();
            //Console.WriteLine(checker.IsValidHand(hand));
            //Console.WriteLine(checker.IsOnePair(hand));
            //Console.WriteLine(checker.IsTwoPair(hand));
        }
    }
}