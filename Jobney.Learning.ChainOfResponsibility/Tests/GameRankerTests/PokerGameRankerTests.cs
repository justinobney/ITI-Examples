using System.Collections.Generic;
using Jobney.Learning.ChainOfResponsibility.Enums;
using Jobney.Learning.ChainOfResponsibility.HandRankers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jobney.Learning.ChainOfResponsibility.Tests.GameRankerTests
{
    [TestClass]
    public class PokerGameRankerTests
    {
        protected PokerGameRanker target;
        protected IEnumerable<Card> hand;

        [TestInitialize]
        public void Init()
        {
            target = new PokerGameRanker();
        }

        [TestClass]
        public class TheRankHandMethod : PokerGameRankerTests
        {
            [TestMethod]
            public void ReturnsRoyalFlushWhenGivenARoyalFlush()
            {
                // Arrange
                const HandRanking expected = HandRanking.RoyalFlush;
                hand = new List<Card>()
                    {
                        new Card(){Suit = CardSuit.Spades, Value = CardValue.Ace},
                        new Card(){Suit = CardSuit.Spades, Value = CardValue.King},
                        new Card(){Suit = CardSuit.Spades, Value = CardValue.Queen},
                        new Card(){Suit = CardSuit.Spades, Value = CardValue.Jack},
                        new Card(){Suit = CardSuit.Spades, Value = CardValue.Ten}
                    };

                // Act
                var actual = target.Rank(hand);

                // Assert
                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void ReturnsStraightFlushWhenGivenAStraightFlush()
            {
                // Arrange
                const HandRanking expected = HandRanking.StraightFlush;
                hand = new List<Card>()
                    {
                        new Card(){Suit = CardSuit.Spades, Value = CardValue.Nine},
                        new Card(){Suit = CardSuit.Spades, Value = CardValue.King},
                        new Card(){Suit = CardSuit.Spades, Value = CardValue.Queen},
                        new Card(){Suit = CardSuit.Spades, Value = CardValue.Jack},
                        new Card(){Suit = CardSuit.Spades, Value = CardValue.Ten}
                    };

                // Act
                var actual = target.Rank(hand);

                // Assert
                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void ReturnsFourOfAKindWhenGivenAFourOfAKind()
            {
                // Arrange
                const HandRanking expected = HandRanking.FourOfAKind;
                hand = new List<Card>()
                    {
                        new Card(){Suit = CardSuit.Spades, Value = CardValue.Nine},
                        new Card(){Suit = CardSuit.Diamonds, Value = CardValue.Nine},
                        new Card(){Suit = CardSuit.Clubs, Value = CardValue.Nine},
                        new Card(){Suit = CardSuit.Hearts, Value = CardValue.Nine},
                        new Card(){Suit = CardSuit.Spades, Value = CardValue.Ten}
                    };

                // Act
                var actual = target.Rank(hand);

                // Assert
                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void ReturnsFullHouseWhenGivenAFullHouse()
            {
                // Arrange
                const HandRanking expected = HandRanking.FullHouse;
                hand = new List<Card>()
                    {
                        new Card(){Suit = CardSuit.Spades, Value = CardValue.Nine},
                        new Card(){Suit = CardSuit.Spades, Value = CardValue.Seven},
                        new Card(){Suit = CardSuit.Clubs, Value = CardValue.Nine},
                        new Card(){Suit = CardSuit.Hearts, Value = CardValue.Nine},
                        new Card(){Suit = CardSuit.Diamonds, Value = CardValue.Seven}
                    };

                // Act
                var actual = target.Rank(hand);

                // Assert
                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void ReturnsFlushWhenGivenAFlush()
            {
                // Arrange
                const HandRanking expected = HandRanking.Flush;
                hand = new List<Card>()
                    {
                        new Card(){Suit = CardSuit.Spades, Value = CardValue.King},
                        new Card(){Suit = CardSuit.Spades, Value = CardValue.Jack},
                        new Card(){Suit = CardSuit.Spades, Value = CardValue.Four},
                        new Card(){Suit = CardSuit.Spades, Value = CardValue.Nine},
                        new Card(){Suit = CardSuit.Spades, Value = CardValue.Seven}
                    };

                // Act
                var actual = target.Rank(hand);

                // Assert
                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void ReturnsStraightWhenGivenAStraight()
            {
                // Arrange
                const HandRanking expected = HandRanking.Straight;
                hand = new List<Card>()
                    {
                        new Card(){Suit = CardSuit.Spades, Value = CardValue.Nine},
                        new Card(){Suit = CardSuit.Spades, Value = CardValue.Seven},
                        new Card(){Suit = CardSuit.Clubs, Value = CardValue.Eight},
                        new Card(){Suit = CardSuit.Hearts, Value = CardValue.Six},
                        new Card(){Suit = CardSuit.Diamonds, Value = CardValue.Five}
                    };

                // Act
                var actual = target.Rank(hand);

                // Assert
                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void ReturnsThreeOfAKindWhenGivenAThreeOfAKind()
            {
                // Arrange
                const HandRanking expected = HandRanking.ThreeOfAKind;
                hand = new List<Card>()
                    {
                        new Card(){Suit = CardSuit.Clubs, Value = CardValue.Three},
                        new Card(){Suit = CardSuit.Spades, Value = CardValue.Three},
                        new Card(){Suit = CardSuit.Clubs, Value = CardValue.Five},
                        new Card(){Suit = CardSuit.Hearts, Value = CardValue.Three},
                        new Card(){Suit = CardSuit.Diamonds, Value = CardValue.Six}
                    };

                // Act
                var actual = target.Rank(hand);

                // Assert
                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void ReturnsTwoPairWhenGivenATwoPair()
            {
                // Arrange
                const HandRanking expected = HandRanking.TwoPair;
                hand = new List<Card>()
                    {
                        new Card(){Suit = CardSuit.Spades, Value = CardValue.Nine},
                        new Card(){Suit = CardSuit.Spades, Value = CardValue.Seven},
                        new Card(){Suit = CardSuit.Clubs, Value = CardValue.Nine},
                        new Card(){Suit = CardSuit.Hearts, Value = CardValue.Jack},
                        new Card(){Suit = CardSuit.Diamonds, Value = CardValue.Seven}
                    };

                // Act
                var actual = target.Rank(hand);

                // Assert
                Assert.AreEqual(expected, actual);
            }
            
            [TestMethod]
            public void ReturnsPairWhenGivenAPair()
            {
                // Arrange
                const HandRanking expected = HandRanking.Pair;
                hand = new List<Card>()
                    {
                        new Card(){Suit = CardSuit.Spades, Value = CardValue.Nine},
                        new Card(){Suit = CardSuit.Spades, Value = CardValue.Seven},
                        new Card(){Suit = CardSuit.Clubs, Value = CardValue.Four},
                        new Card(){Suit = CardSuit.Hearts, Value = CardValue.Jack},
                        new Card(){Suit = CardSuit.Diamonds, Value = CardValue.Seven}
                    };

                // Act
                var actual = target.Rank(hand);

                // Assert
                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void ReturnsHighCardWhenGivenAHighCard()
            {
                // Arrange
                const HandRanking expected = HandRanking.HighCard;
                hand = new List<Card>()
                    {
                        new Card(){Suit = CardSuit.Spades, Value = CardValue.Nine},
                        new Card(){Suit = CardSuit.Spades, Value = CardValue.Seven},
                        new Card(){Suit = CardSuit.Clubs, Value = CardValue.Jack},
                        new Card(){Suit = CardSuit.Hearts, Value = CardValue.Queen},
                        new Card(){Suit = CardSuit.Diamonds, Value = CardValue.Two}
                    };

                // Act
                var actual = target.Rank(hand);

                // Assert
                Assert.AreEqual(expected, actual);
            }
        }
    }
}
