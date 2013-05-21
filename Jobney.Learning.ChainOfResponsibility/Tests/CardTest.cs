using Jobney.Learning.ChainOfResponsibility.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jobney.Learning.ChainOfResponsibility.Tests
{
    [TestClass]
    public class CardTest
    {
        public Card target;

        [TestInitialize]
        public void Init()
        {
            target = new Card();
        }

        [TestClass]
        public class TheSuitProperty : CardTest
        {
            [TestMethod]
            public void ReturnsNullByDefault()
            {
                // Arrange

                // Act
                var defaultValue = target.Suit;

                // Assert
                Assert.IsNull(defaultValue);
            }

            [TestMethod]
            public void ReturnsCorrectSuitWhenSet()
            {
                // Arrange
                var expected = CardSuit.Diamonds;

                // Act
                target.Suit = CardSuit.Diamonds;
                var actual = (CardSuit) target.Suit;

                // Assert
                Assert.AreEqual(expected, actual);
            }
        }

        [TestClass]
        public class TheValueProperty : CardTest
        {
            [TestMethod]
            public void ReturnsNullByDefault()
            {
                // Arrange

                // Act
                var defaultValue = target.Value;

                // Assert
                Assert.IsNull(defaultValue);
            }

            [TestMethod]
            public void ReturnsCorrectValueWhenSet()
            {
                // Arrange
                var expected = CardValue.Nine;

                // Act
                target.Value = CardValue.Nine;
                var actual = (CardValue) target.Value;

                // Assert
                Assert.AreEqual(expected, actual);
            }
        }

        [TestClass]
        public class TheIsValidMethod : CardTest
        {
            [TestMethod]
            public void ReturnsFalseByDefault()
            {
                // Arrange

                // Act
                var targetIsValid = target.IsValid();

                // Assert
                Assert.IsFalse(targetIsValid);
            }

            [TestMethod]
            public void ReturnsTrueWhenPropertiesSet()
            {
                // Arrange
                target.Suit = CardSuit.Diamonds;
                target.Value = CardValue.Ace;

                // Act
                var targetIsValid = target.IsValid();

                // Assert
                Assert.IsTrue(targetIsValid);
            }
        }
    }
}