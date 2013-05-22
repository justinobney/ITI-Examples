using System.Collections.Generic;
using Jobney.Learning.ChainOfResponsibility.Enums;

namespace Jobney.Learning.ChainOfResponsibility.HandRankers
{
    public abstract class HandRanker
    {
        protected HandRanker next;
        public bool CanHandle { get; set; }

        protected HandRanker(HandRanker nextRanker)
        {
            this.next = nextRanker;
        }

        protected HandRanker()
        {
            next = null;
        }

        public abstract HandRanking Handle(IEnumerable<Card> hand);
    }
}
