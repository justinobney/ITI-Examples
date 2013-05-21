using Jobney.Learning.ChainOfResponsibility.Enums;

namespace Jobney.Learning.ChainOfResponsibility
{
    public class Card
    {
        public Card()
        {
        }

        public Card(CardSuit suit, CardValue value)
        {
            Suit = suit;
            Value = value;
        }

        public CardSuit? Suit { get; set; }

        public CardValue? Value { get; set; }

        public bool IsValid()
        {
            return Suit != null && Value != null;
        }
    }
}