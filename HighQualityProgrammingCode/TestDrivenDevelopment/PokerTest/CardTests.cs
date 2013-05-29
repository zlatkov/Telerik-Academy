using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace PokerTest
{
    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void Constructor_TestIfCardFaceIsInitialized()
        {
            Card card = new Card(CardFace.Five, CardSuit.Hearts);
            Assert.AreEqual(CardFace.Five, card.Face);
        }

        [TestMethod]
        public void Constructor_TestIfCardSuitIsInitialized()
        {
            Card card = new Card(CardFace.Five, CardSuit.Hearts);
            Assert.AreEqual(CardSuit.Hearts, card.Suit);
        }

        [TestMethod]
        public void ToString_WhenCardFaceIsAce_ShouldFormatTheFaceAsWord()
        {
            Card card = new Card(CardFace.Ace, CardSuit.Hearts);
            Assert.AreEqual("Ace♥", card.ToString());
        }

        [TestMethod]
        public void ToString_WhenCardFaceIs5_ShouldFormatTheFaceAsDigitI()
        {
            Card card = new Card(CardFace.Five, CardSuit.Hearts);
            Assert.AreEqual("5♥", card.ToString());
        }
    }
}
