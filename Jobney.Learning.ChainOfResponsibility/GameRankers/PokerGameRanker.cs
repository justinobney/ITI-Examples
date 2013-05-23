using System.Collections.Generic;
using Jobney.Learning.ChainOfResponsibility.Enums;

namespace Jobney.Learning.ChainOfResponsibility.HandRankers
{
    public class PokerGameRanker
    {
        private readonly HighCardRanker highCardRanker;
        private readonly PairRanker pairRanker;
        private readonly TwoPairRanker twoPairRanker;
        readonly ThreeOfAKindRanker threeOfAKindRanker;
        private readonly StraightRanker straightRanker;
        private readonly FlushRanker flushRanker;
        private readonly FullHouseRanker fullHouseRanker;
        private readonly FourOfAKindRanker fourOfAKindRanker;
        private readonly StraightFlushRanker straightFlushRanker;
        private readonly RoyalFlushRanker royalFlushRanker;

        public PokerGameRanker()
        {
            highCardRanker = new HighCardRanker();
            pairRanker = new PairRanker(highCardRanker);
            twoPairRanker = new TwoPairRanker(pairRanker);
            threeOfAKindRanker = new ThreeOfAKindRanker(twoPairRanker);
            straightRanker = new StraightRanker(threeOfAKindRanker);
            flushRanker = new FlushRanker(straightRanker);
            fullHouseRanker = new FullHouseRanker(flushRanker);
            fourOfAKindRanker = new FourOfAKindRanker(fullHouseRanker);
            straightFlushRanker = new StraightFlushRanker(fourOfAKindRanker);
            royalFlushRanker = new RoyalFlushRanker(straightFlushRanker);
        }

        public HandRanking Rank(IEnumerable<Card> hand)
        {
            return royalFlushRanker.Handle(hand);
        }
    }
}