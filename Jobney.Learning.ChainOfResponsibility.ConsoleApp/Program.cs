using System;
using System.Linq;
using Jobney.Learning.ChainOfResponsibility.Enums;
using Jobney.Learning.ChainOfResponsibility.HandRankers;

namespace Jobney.Learning.ChainOfResponsibility.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Deck deck;
            var pokerRanker = new PokerGameRanker();

            var highCardCounter = 0;
            var pairCounter = 0;
            var twoPairCounter = 0;
            var threeOfAKindCounter = 0;
            var straightCounter = 0;
            var flushCounter = 0;
            var fullHouseCounter = 0;
            var fourOfAKindCounter = 0;
            var straightFlushCounter = 0;
            var royalFlushCounter = 0;

            const int gamesToPlay = 10000;
            const int handsPerGame = 8;

            for (int i = 0; i < gamesToPlay; i++)
            {
                deck = new Deck();
                for (int j = 0; j < handsPerGame; j++)
                {
                    var hand = deck.Deal(5);

                    switch (pokerRanker.Rank(hand))
                    {
                            case HandRanking.HighCard:
                                highCardCounter++;
                                break;
                            case HandRanking.Pair:
                                pairCounter++;
                                break;
                            case HandRanking.TwoPair:
                                twoPairCounter++;
                                break;
                            case HandRanking.ThreeOfAKind:
                                threeOfAKindCounter++;
                                break;
                            case HandRanking.Straight:
                                straightCounter++;
                                break;
                            case HandRanking.Flush:
                                flushCounter++;
                                break;
                            case HandRanking.FullHouse:
                                fullHouseCounter++;
                                break;
                            case HandRanking.FourOfAKind:
                                fourOfAKindCounter++;
                                break;
                            case HandRanking.StraightFlush:
                                straightFlushCounter++;
                                break;
                            case HandRanking.RoyalFlush:
                                royalFlushCounter++;
                                break;
                    }
                }
            }

            Console.WriteLine("Games Played ------  {0}", gamesToPlay);
            Console.WriteLine("Total Hands Dealt -  {0}", gamesToPlay * handsPerGame);
            Console.WriteLine("===================");
            Console.WriteLine("High Card ---------  {0}", highCardCounter);
            Console.WriteLine("Pair --------------  {0}", pairCounter);
            Console.WriteLine("Two Pair ----------  {0}", twoPairCounter);
            Console.WriteLine("Three of a Kind ---  {0}", threeOfAKindCounter);
            Console.WriteLine("Straight ----------  {0}", straightCounter);
            Console.WriteLine("Flush -------------  {0}", flushCounter);
            Console.WriteLine("Full House --------  {0}", fullHouseCounter);
            Console.WriteLine("Four of a Kind ----  {0}", fourOfAKindCounter);
            Console.WriteLine("Straight Flush ----  {0}", straightFlushCounter);
            Console.WriteLine("Royal Flush -------  {0}", royalFlushCounter);
            Console.ReadLine();
        }
    }
}