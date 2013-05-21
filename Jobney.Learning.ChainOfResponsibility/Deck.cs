using System;
using System.Collections.Generic;
using System.Linq;
using Jobney.Learning.ChainOfResponsibility.Enums;
using Jobney.Learning.ChainOfResponsibility.ExtensionMethods;

namespace Jobney.Learning.ChainOfResponsibility
{
    public class Deck
    {
        public Deck()
        {
            Cards = new List<Card>();
            InitDeck();
        }

        public IEnumerable<Card> Cards { get; private set; }

        private void InitDeck()
        {
            for (var i = 0; i < Enum.GetNames(typeof(CardSuit)).Length; i++)
            {
                var suit = (CardSuit) i;

                for (var j = 0; j < Enum.GetNames(typeof(CardValue)).Length; j++)
                {
                    var value = (CardValue) j;
                    ((List<Card>) Cards).Add(new Card(suit, value));
                }
            }

            Cards = Cards.Shuffle(new Random());
        }

        public IEnumerable<Card> Deal(int numOfCards)
        {
            var cardsDealt = new List<Card>();

            for (var i = 0; i < numOfCards; i++)
            {
                var enumerable = Cards.ToArray();
                var card = enumerable.ElementAt(0);
                cardsDealt.Add(card);
                Cards = enumerable.Except(new List<Card>() {card});
            }

            return cardsDealt;
        }
    }
}