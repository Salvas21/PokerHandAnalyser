using System.Collections.Generic;
using System.Linq;

namespace Poker.Models.HandHandlers
{
    public class StraightFlushHandler : HandHandler
    {
        public override void Handle(IHandlerRequest request)
        {
            var handRequest = (HandRequest) request;
            
            if (!HasStraightFlush(handRequest.Cards.ToList()))
            {
                Next?.Handle(request);
            }
            else
            {
                handRequest.Hand = Hand.StraightFlush;
            }
        }

        private bool HasStraightFlush(List<Card> cards)
        {
            return HandHandlerHelper.HasFollowingOfCards(cards) && HandHandlerHelper.HasSameSuit(cards);
        }
    }
}