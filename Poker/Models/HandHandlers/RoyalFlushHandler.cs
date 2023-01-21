using System.Collections.Generic;
using System.Linq;

namespace Poker.Models.HandHandlers
{
    public class RoyalFlushHandler : HandHandler
    {
        public override void Handle(IHandlerRequest request)
        {
            var handRequest = (HandRequest) request;
            
            if (!HasRoyalFlush(handRequest.Cards.ToList()))
            {
                Next?.Handle(request);
            }
            else
            {
                handRequest.Hand = Hand.RoyalFlush;
            }
        }
        
        private bool HasRoyalFlush(List<Card> cards)
        {
            return HasRoyal(cards) && HandHandlerHelper.HasSameSuit(cards);
        }

        private bool HasRoyal(List<Card> cards)
        {
            var template = HandHandlerHelper.GenerateRoyalCards();
            var amount = HandHandlerHelper.GetContainedAmount(cards, template);
            
            return amount + HandHandlerHelper.HowMuchJokers(cards) == 5;
        }
        
    }
}