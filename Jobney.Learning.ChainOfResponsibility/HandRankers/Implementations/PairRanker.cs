using System.Collections.Generic;
using System.Linq;
using Jobney.Learning.ChainOfResponsibility.Enums;

namespace Jobney.Learning.ChainOfResponsibility.HandRankers
{
    public class PairRanker : HandRanker
    {
        public PairRanker(HandRanker nextRanker) : base(nextRanker)
        {

        }

        public override HandRanking Handle(IEnumerable<Card> hand)
        {
            if (hand.GroupBy(x => x.Value.Value).Any(grp => grp.Count() == 2))
            {
                CanHandle = true;
                return HandRanking.Pair;
            }
            return next.Handle(hand);
        }
    }
}