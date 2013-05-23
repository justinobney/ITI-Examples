using System.Collections.Generic;
using Jobney.Learning.ChainOfResponsibility.Enums;
using Jobney.Learning.ChainOfResponsibility.HandRankers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jobney.Learning.ChainOfResponsibility.Tests
{
    [TestClass]
    public class TwoPairRankerTest
    {
        public TwoPairRanker target;
        public HighCardRanker highcardRanker;
        private IEnumerable<Card> hand;

        [TestInitialize]
        public void Init()
        {
            highcardRanker = new HighCardRanker();
            target = new TwoPairRanker(highcardRanker);
        }

        [TestClass]
        public class TheHandleMethod : TwoPairRankerTest
        {
            [TestMethod]
            public void ReturnsTwoPairRankWhenHandContainsATwoPair()
            {
                // Arrange
                var expected = HandRanking.TwoPair;
                hand = new List<Card>()
                    {
                        new Card(){Suit = CardSuit.Clubs, Value = CardValue.Ace},
                        new Card(){Suit = CardSuit.Hearts, Value = CardValue.Ace},
                        new Card(){Suit = CardSuit.Spades, Value = CardValue.Eight},
                        new Card(){Suit = CardSuit.Diamonds, Value = CardValue.Five},
                        new Card(){Suit = CardSuit.Clubs, Value = CardValue.Eight}
                    };

                // Act
                var actual = target.Handle(hand);

                // Assert
                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void ReturnsHighCardRankWhenNoTwoPairExists()
            {
                // Arrange
                var expected = HandRanking.HighCard;
                hand = new List<Card>()
                    {
                        new Card(){Suit = CardSuit.Clubs, Value = CardValue.Queen},
                        new Card(){Suit = CardSuit.Hearts, Value = CardValue.Ace},
                        new Card(){Suit = CardSuit.Spades, Value = CardValue.Queen},
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
