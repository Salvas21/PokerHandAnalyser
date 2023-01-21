using System.Collections.Generic;
using System.Linq;

namespace Poker.Models.HandHandlers
{
    public class FlushHandler : HandHandler
    {
        public override void Handle(IHandlerRequest request)
        {
            var handRequest = (HandRequest) request;
            
            if (!HasFlush(handRequest.Cards.ToList()))
            {
                Next?.Handle(request);
            }
            else
            {
                handRequest.Hand = Hand.Flush;
            }
        }

        private bool HasFlush(List<Card> cards)
        {
            return HandHandlerHelper.HasSameSuit(cards);
        }
    }
}