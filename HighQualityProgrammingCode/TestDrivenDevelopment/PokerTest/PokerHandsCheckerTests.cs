using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace PokerTest
{
    [TestClass]
    public class PokerHandsCheckerTests
    {
        [TestMethod]
        public void IsValidHand_CheckWitHDifferentCards()
        {
            var cards = new List<ICard>() {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds)
            };

            var hand = new Hand(cards);
            var pokerHandsChecker = new PokerHandsChecker();
            Assert.IsTrue(pokerHandsChecker.IsValidHand(hand));
        }

        [TestMethod]
        public void IsValidHand_CheckWith4DifferentCards()
        {
            var cards = new List<ICard>() {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs)
            };

            var hand = new Hand(cards);
            var pokerHandsChecker = new PokerHandsChecker();
            Assert.IsFalse(pokerHandsChecker.IsValidHand(hand));
        }

        [TestMethod]
        public void IsFourOfAKind_CheckWith4CardsOfSameKind()
        {
            var cards = new List<ICard>() {
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs)
            };

            var hand = new Hand(cards);
            var pokerHandsChecker = new PokerHandsChecker();
            Assert.IsTrue(pokerHandsChecker.IsFourOfAKind(hand));
        }

        [TestMethod]
        public void IsFourOfAKind_CheckWithout4CardsOfSameKind()
        {
            var cards = new List<ICard>() {
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs)
            };

            var hand = new Hand(cards);
            var pokerHandsChecker = new PokerHandsChecker();
            Assert.IsFalse(pokerHandsChecker.IsFourOfAKind(hand));
        }

        [TestMethod]
        public void IsFlush_CheckWithFlush()
        {
            var cards = new List<ICard>() {
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs)
            };

            var hand = new Hand(cards);
            var pokerHandsChecker = new PokerHandsChecker();
            Assert.IsTrue(pokerHandsChecker.IsFlush(hand));
        }

        [TestMethod]
        public void IsFlush_CheckWithoutFlush()
        {
            var cards = new List<ICard>() {
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Hearts)
            };

            var hand = new Hand(cards);
            var pokerHandsChecker = new PokerHandsChecker();
            Assert.IsFalse(pokerHandsChecker.IsFlush(hand));
        }
    }
}
