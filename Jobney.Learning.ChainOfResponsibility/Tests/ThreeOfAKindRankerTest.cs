using System.Collections.Generic;
using Jobney.Learning.ChainOfResponsibility.Enums;
using Jobney.Learning.ChainOfResponsibility.HandRankers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jobney.Learning.ChainOfResponsibility.Tests
{
    [TestClass]
    public class ThreeOfAKindRankerTest
    {
        public ThreeOfAKindRanker target;
        public HighCardRanker highcardRanker;
        private IEnumerable<Card> hand;

        [TestInitialize]
        public void Init()
        {
            highcardRanker = new HighCardRanker();
            target = new ThreeOfAKindRanker(highcardRanker);
        }

        [TestClass]
        public class TheHandleMethod : ThreeOfAKindRankerTest
        {
            [TestMethod]
            public void ReturnsThreeOfAKindRankWhenHandContainsThreeOfAKind()
            {
                // Arrange
                var expected = HandRanking.ThreeOfAKind;
                hand = new List<Card>()
                    {
                        new Card(){Suit = CardSuit.Clubs, Value = CardValue.Ace},
                        new Card(){Suit = CardSuit.Hearts, Value = CardValue.Ace},
                        new Card(){Suit = CardSuit.Spades, Value = CardValue.Eight},
                        new Card(){Suit = CardSuit.Diamonds, Value = CardValue.Ace},
                        new Card(){Suit = CardSuit.Clubs, Value = CardValue.Jack}
                    };
                
                // Act
                var actual = target.Handle(hand);

                // Assert
                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void ReturnsHighCardRankWhenNoThreeOfAKindExists()
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
