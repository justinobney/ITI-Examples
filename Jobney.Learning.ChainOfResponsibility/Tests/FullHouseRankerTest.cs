using System.Collections.Generic;
using Jobney.Learning.ChainOfResponsibility.Enums;
using Jobney.Learning.ChainOfResponsibility.HandRankers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jobney.Learning.ChainOfResponsibility.Tests
{
    [TestClass]
    public class FullHouseRankerTest
    {
        public FullHouseRanker target;
        public HighCardRanker highcardRanker;
        private IEnumerable<Card> hand;

        [TestInitialize]
        public void Init()
        {
            highcardRanker = new HighCardRanker();
            target = new FullHouseRanker(highcardRanker);
        }

        [TestClass]
        public class TheHandleMethod : FullHouseRankerTest
        {
            [TestMethod]
            public void ReturnsFullHouseRankWhenHandContainsFullHouse()
            {
                // Arrange
                var expected = HandRanking.FullHouse;
                hand = new List<Card>()
                    {
                        new Card(){Suit = CardSuit.Clubs, Value = CardValue.Ace},
                        new Card(){Suit = CardSuit.Hearts, Value = CardValue.Ace},
                        new Card(){Suit = CardSuit.Spades, Value = CardValue.Eight},
                        new Card(){Suit = CardSuit.Diamonds, Value = CardValue.Ace},
                        new Card(){Suit = CardSuit.Clubs, Value = CardValue.Eight}
                    };

                // Act
                var actual = target.Handle(hand);

                // Assert
                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void ReturnsHighCardRankWhenNoFullHouseExists()
            {
                // Arrange
                var expected = HandRanking.HighCard;
                hand = new List<Card>()
                    {
                        new Card(){Suit = CardSuit.Clubs, Value = CardValue.Ace},
                        new Card(){Suit = CardSuit.Hearts, Value = CardValue.Ace},
                        new Card(){Suit = CardSuit.Spades, Value = CardValue.Ace},
                        new Card(){Suit = CardSuit.Diamonds, Value = CardValue.Five},
                        new Card(){Suit = CardSuit.Clubs, Value = CardValue.Jack}
                    };

                // Act
                var actual = target.Handle(hand);

                // Assert
                Assert.AreEqual(expected, actual);
            }
        }
    }
}
