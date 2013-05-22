using System.Collections.Generic;
using System.Linq;
using Jobney.Learning.ChainOfResponsibility.Enums;

namespace Jobney.Learning.ChainOfResponsibility.HandRankers
{
    public class FourOfAKindRanker : HandRanker
    {
        public FourOfAKindRanker(HandRanker nextRanker)
            : base(nextRanker)
        {

        }

        public override HandRanking Handle(IEnumerable<Card> hand)
        {
            if (hand.GroupBy(x => x.Value.Value).Any(grp => grp.Count() == 4))
            {
                CanHandle = true;
                return HandRanking.FourOfAKind;
            }
            return next.Handle(hand);
        }
    }
}
