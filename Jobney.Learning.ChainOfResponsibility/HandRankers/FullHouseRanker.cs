using System.Collections.Generic;
using System.Linq;
using Jobney.Learning.ChainOfResponsibility.Enums;

namespace Jobney.Learning.ChainOfResponsibility.HandRankers
{
    public class FullHouseRanker : HandRanker
    {
        public FullHouseRanker(HandRanker nextRanker) : base(nextRanker)
        {
            
        }
        public override HandRanking Handle(IEnumerable<Card> hand)
        {
            var groups = hand.GroupBy(x => x.Value.Value);
            if (groups.Any(grp => grp.Count() == 3) && groups.Any(grp => grp.Count() == 2))
            {
                CanHandle = true;
                return HandRanking.FullHouse;
            }
            return next.Handle(hand);
        }
    }
}