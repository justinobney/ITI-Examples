using System;
using System.Linq;

namespace Jobney.Learning.ChainOfResponsibility.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var deck = new Deck();

            for (int i = 0; i < 10; i++)
            {
                var hand = deck.Deal(5);
                Console.WriteLine("============ Hand {0} ============", i);
                foreach (var card in hand)
                {
                    Console.WriteLine("Card :: {0} of {1}", card.Value, card.Suit);
                }

                Console.WriteLine("Cards Remaining: {0}", deck.Cards.Count());
                Console.WriteLine("");
            }

            Console.ReadLine();
        }
    }
}