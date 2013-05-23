using System.Collections.Generic;
using Jobney.Learning.ChainOfResponsibility.Enums;

namespace Jobney.Learning.ChainOfResponsibility.HandRankers
{
    public class HighCardRanker : HandRanker
    {
        public override HandRanking Handle(IEnumerable<Card> hand)
        {
            return HandRanking.HighCard;
        }
    }
}