using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace PokerTest
{
    [TestClass]
    public class HandTests
    {
        [TestMethod]
        public void Constructor_InitializesWith5Cards()
        {
            var cards = new List<ICard>() {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds)
            };
            var hand = new Hand(cards);
            Assert.AreEqual(5, hand.Cards.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_InitializesWith4Cards()
        {
            var cards = new List<ICard>() {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
            };
            var hand = new Hand(cards);
        }

        [TestMethod]
        public void ToString_TestFormatting()
        {
            var cards = new List<ICard>() {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds),
            };
            var hand = new Hand(cards);
            Assert.AreEqual("Ace♣, Ace♦, King♥, King♠, 7♦", hand.ToString());
        }
    }
}
