using System.Collections.Generic;
using System.Linq;

namespace Poker.Models.HandHandlers
{
    public class FourOfKindHandler : HandHandler
    {
        public override void Handle(IHandlerRequest request)
        {
            var handRequest = (HandRequest) request;
            
            if (!HasFourOfKind(handRequest.Cards.ToList()))
            {
                Next?.Handle(request);
            }
            else
            {
                handRequest.Hand = Hand.FourOfAKind;
            }
        }

        private bool HasFourOfKind(List<Card> cards)
        {
            var hasFour = HandHandlerHelper.HasAmountOfCards(cards, 4, 1);
            var hasThreeAndJoker = HandHandlerHelper.HasAmountOfCards(cards, 3, 1) 
                                   && HandHandlerHelper.HasJoker(cards);
            var hasTwoAndJokers = HandHandlerHelper.HasAmountOfCards(cards, 2, 1) 
                                  && HandHandlerHelper.HasJokers(cards, 2);
            return hasFour || hasThreeAndJoker || hasTwoAndJokers;
        }
    }
}