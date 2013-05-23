using System.Collections.Generic;
using Jobney.Learning.ChainOfResponsibility.Enums;
using Jobney.Learning.ChainOfResponsibility.HandRankers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jobney.Learning.ChainOfResponsibility.Tests
{
    [TestClass]
    public class FlushRankerTest
    {
        public FlushRanker target;
        public HighCardRanker highcardRanker;
        private IEnumerable<Card> hand;

        [TestInitialize]
        public void Init()
        {
            highcardRanker = new HighCardRanker();
            target = new FlushRanker(highcardRanker);
        }

        [TestClass]
        public class TheHandleMethod : FlushRankerTest
        {
            [TestMethod]
            public void ReturnsFlushRankWhenHandContainsFlush()
            {
                // Arrange
                var expected = HandRanking.Flush;
                hand = new List<Card>()
                    {
                        new Card(){Suit = CardSuit.Clubs, Value = CardValue.Nine},
                        new Card(){Suit = CardSuit.Clubs, Value = CardValue.Six},
                        new Card(){Suit = CardSuit.Clubs, Value = CardValue.Eight},
                        new Card(){Suit = CardSuit.Clubs, Value = CardValue.Ace},
                        new Card(){Suit = CardSuit.Clubs, Value = CardValue.Jack}
                    };

                // Act
                var actual = target.Handle(hand);

                // Assert
                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void ReturnsHighCardRankWhenNoFlushExists()
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
