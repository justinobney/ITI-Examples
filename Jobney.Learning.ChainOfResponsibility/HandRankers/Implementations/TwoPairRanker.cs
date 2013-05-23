using System.Collections.Generic;
using System.Linq;
using Jobney.Learning.ChainOfResponsibility.Enums;

namespace Jobney.Learning.ChainOfResponsibility.HandRankers
{
    public class TwoPairRanker : HandRanker
    {
        public TwoPairRanker(HandRanker nextRanker): base(nextRanker)
        {

        }

        public override HandRanking Handle(IEnumerable<Card> hand)
        {
            if (hand.GroupBy(x => x.Value.Value).Where(grp => grp.Count() == 2).Count() == 2)
            {
                CanHandle = true;
                return HandRanking.TwoPair;
            }
            return next.Handle(hand);
        }
    }
}