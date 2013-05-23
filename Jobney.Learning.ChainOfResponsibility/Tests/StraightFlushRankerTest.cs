using System.Collections.Generic;
using Jobney.Learning.ChainOfResponsibility.Enums;
using Jobney.Learning.ChainOfResponsibility.HandRankers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jobney.Learning.ChainOfResponsibility.Tests
{
    public class StraightFlushRankerTest
    {
        public StraightFlushRanker target;
        public HighCardRanker highcardRanker;
        private IEnumerable<Card> hand;

        [TestInitialize]
        public void Init()
        {
            highcardRanker = new HighCardRanker();
            target = new StraightFlushRanker(highcardRanker);
        }

        [TestClass]
        public class TheHandleMethod : StraightFlushRankerTest
        {
            [TestMethod]
            public void ReturnsStraightFlushRankWhenHandContainsAStraightFlush()
            {
                // Arrange
                var expected = HandRanking.StraightFlush;
                hand = new List<Card>()
                    {
                        new Card(){Suit = CardSuit.Spades, Value = CardValue.Two},
                        new Card(){Suit = CardSuit.Spades, Value = CardValue.Three},
                        new Card(){Suit = CardSuit.Spades, Value = CardValue.Six},
                        new Card(){Suit = CardSuit.Spades, Value = CardValue.Five},
                        new Card(){Suit = CardSuit.Spades, Value = CardValue.Four}
                    };

                // Act
                var actual = target.Handle(hand);

                // Assert
                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void ReturnsHighCardRankWhenNoStraightFlushExists()
            {
                // Arrange
                var expected = HandRanking.HighCard;
                hand = new List<Card>()
                    {
                        new Card(){Suit = CardSuit.Diamonds, Value = CardValue.Two},
                        new Card(){Suit = CardSuit.Spades, Value = CardValue.Three},
                        new Card(){Suit = CardSuit.Spades, Value = CardValue.Six},
                        new Card(){Suit = CardSuit.Spades, Value = CardValue.Five},
                        new Card(){Suit = CardSuit.Spades, Value = CardValue.Four}
                    };

                // Act
                var actual = target.Handle(hand);

                // Assert
                Assert.AreEqual(expected, actual);
            }
        }
    }
}
