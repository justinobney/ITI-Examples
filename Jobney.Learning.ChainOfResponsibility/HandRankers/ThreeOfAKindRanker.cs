using System.Collections.Generic;
using System.Linq;
using Jobney.Learning.ChainOfResponsibility.Enums;

namespace Jobney.Learning.ChainOfResponsibility.HandRankers
{
    public class ThreeOfAKindRanker : HandRanker
    {
        public ThreeOfAKindRanker(HandRanker nextRanker) : base(nextRanker)
        {
            
        }

        public override HandRanking Handle(IEnumerable<Card> hand)
        {
            if (hand.GroupBy(x => x.Value.Value).Any(grp => grp.Count() == 3))
            {
                CanHandle = true;
                return HandRanking.ThreeOfAKind;
            }
            return next.Handle(hand);
        }
    }
}