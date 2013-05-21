using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jobney.Learning.ChainOfResponsibility.Tests
{
    [TestClass]
    public class DeckTest
    {
        public Deck target;

        [TestInitialize]
        public void Init()
        {
            target = new Deck();
        }

        [TestClass]
        public class TheCardsProperty : DeckTest
        {
            [TestMethod]
            public void Has52CardsWhenInitialized()
            {
                // Arrange
                var expected = 52;

                // Act
                var actual = target.Cards.Count();

                // Assert
                Assert.AreEqual(expected, actual);
            }
        }

        [TestClass]
        public class TheDealMethod : DeckTest
        {
            [TestMethod]
            public void HasDeckContaining45CardsAfterDealing7()
            {
                // Arrange
                var expected = 45;

                // Act
                target.Deal(7);
                var actual = target.Cards.Count();

                // Assert
                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void ReturnsAHandContainingCorrectNumOfCards()
            {
                // Arrange
                var expected = 5;

                // Act
                var hand = target.Deal(5);
                var actual = hand.Count();

                // Assert
                Assert.AreEqual(expected, actual);
            }
        }
    }
}