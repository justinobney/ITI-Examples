using System.Collections.Generic;
using System.Linq;
using Jobney.Learning.ChainOfResponsibility.Enums;

namespace Jobney.Learning.ChainOfResponsibility.HandRankers
{
    public class FlushRanker : HandRanker
    {
        public FlushRanker(HandRanker nextRanker) : base(nextRanker)
        {
            
        }
        public override HandRanking Handle(IEnumerable<Card> hand)
        {
            if (hand.GroupBy(x => x.Suit.Value).Any(grp => grp.Count() == 5))
            {
                CanHandle = true;
                return HandRanking.Flush;
            }
            return next.Handle(hand);
        }
    }
}