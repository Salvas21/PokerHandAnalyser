using System.Collections.Generic;
using System.Linq;

namespace Poker.Models.HandHandlers
{
    public class TwoPairHandler : HandHandler
    {
        public override void Handle(IHandlerRequest request)
        {
            var handRequest = (HandRequest) request;
            
            if (!HasTwoPair(handRequest.Cards.ToList()))
            {
                Next?.Handle(request);
            }
            else
            {
                handRequest.Hand = Hand.TwoPair;
            }
        }

        private bool HasTwoPair(List<Card> cards)
        {
            return HandHandlerHelper.HasAmountOfCards(cards, 2, 2);
        }
    }
}