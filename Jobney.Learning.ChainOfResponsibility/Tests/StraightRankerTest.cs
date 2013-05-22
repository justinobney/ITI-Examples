using System.Collections.Generic;
using Jobney.Learning.ChainOfResponsibility.Enums;
using Jobney.Learning.ChainOfResponsibility.HandRankers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jobney.Learning.ChainOfResponsibility.Tests
{
    public class StraightRankerTest
    {
        public StraightRanker target;
        public HighCardRanker highcardRanker;
        private IEnumerable<Card> hand;

        [TestInitialize]
        public void Init()
        {
            highcardRanker = new HighCardRanker();
            target = new StraightRanker(highcardRanker);
        }

        [TestClass]
        public class TheHandleMethod : StraightRankerTest
        {
            [TestMethod]
            public void ReturnsStraightRankWhenHandContainsAStraight()
            {
                // Arrange
                var expected = HandRanking.Straight;
                hand = new List<Card>()
                    {
                        new Card(){Suit = CardSuit.Clubs, Value = CardValue.Two},
                        new Card(){Suit = CardSuit.Hearts, Value = CardValue.Three},
                        new Card(){Suit = CardSuit.Spades, Value = CardValue.Six},
                        new Card(){Suit = CardSuit.Diamonds, Value = CardValue.Five},
                        new Card(){Suit = CardSuit.Clubs, Value = CardValue.Four}
                    };

                // Act
                var actual = target.Handle(hand);

                // Assert
                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void ReturnsHighCardRankWhenNoStraightExists()
            {
                // Arrange
                var expected = HandRanking.HighCard;
                hand = new List<Card>()
                    {
                        new Card(){Suit = CardSuit.Clubs, Value = CardValue.Queen},
                        new Card(){Suit = CardSuit.Hearts, Value = CardValue.Ace},
                        new Card(){Suit = CardSuit.Spades, Value = CardValue.Eight},
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
