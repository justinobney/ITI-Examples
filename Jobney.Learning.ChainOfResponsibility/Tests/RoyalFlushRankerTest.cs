using System.Collections.Generic;
using Jobney.Learning.ChainOfResponsibility.Enums;
using Jobney.Learning.ChainOfResponsibility.HandRankers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jobney.Learning.ChainOfResponsibility.Tests
{
    public class RoyalFlushRankerTest
    {
        public RoyalFlushRanker target;
        public HighCardRanker highcardRanker;
        private IEnumerable<Card> hand;

        [TestInitialize]
        public void Init()
        {
            highcardRanker = new HighCardRanker();
            target = new RoyalFlushRanker(highcardRanker);
        }

        [TestClass]
        public class TheHandleMethod : RoyalFlushRankerTest
        {
            [TestMethod]
            public void ReturnsRoyalFlushRankWhenHandContainsARoyalFlush()
            {
                // Arrange
                var expected = HandRanking.RoyalFlush;
                hand = new List<Card>()
                    {
                        new Card(){Suit = CardSuit.Spades, Value = CardValue.Ace},
                        new Card(){Suit = CardSuit.Spades, Value = CardValue.King},
                        new Card(){Suit = CardSuit.Spades, Value = CardValue.Queen},
                        new Card(){Suit = CardSuit.Spades, Value = CardValue.Jack},
                        new Card(){Suit = CardSuit.Spades, Value = CardValue.Ten}
                    };

                // Act
                var actual = target.Handle(hand);

                // Assert
                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void ReturnsHighCardRankWhenNoRoyalFlushExists()
            {
                // Arrange
                var expected = HandRanking.HighCard;
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
        }
    }
}
