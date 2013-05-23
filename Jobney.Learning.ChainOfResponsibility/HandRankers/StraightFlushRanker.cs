using System;
using System.Collections.Generic;
using System.Linq;
using Jobney.Learning.ChainOfResponsibility.Enums;

namespace Jobney.Learning.ChainOfResponsibility.HandRankers
{
    public class StraightFlushRanker : HandRanker
    {
        public StraightFlushRanker(HandRanker nextRanker) : base(nextRanker)
        {
            
        }

        public override HandRanking Handle(IEnumerable<Card> hand)
        {

            if (!hand.GroupBy(x => x.Suit.Value).Any(grp => grp.Count() == 5))
            {
                return next.Handle(hand);
            }

            var valueArray = hand.Select(c => (int)c.Value).ToArray();
            Array.Sort(valueArray);

            CanHandle = true;

            for (int i = 0; i < valueArray.Length - 1; i++)
            {
                if ((valueArray[i] + 1) != valueArray[i + 1])
                {
                    CanHandle = false;
                    return next.Handle(hand);
                }
            }
            return HandRanking.StraightFlush;
        }
    }
}