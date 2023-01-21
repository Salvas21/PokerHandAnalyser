using System.Collections.Generic;
using System.Linq;

namespace Poker.Models.HandHandlers
{
    public class ThreeOfKindHandler : HandHandler
    {
        public override void Handle(IHandlerRequest request)
        {
            var handRequest = (HandRequest) request;
            
            if (!HasThreeOfKind(handRequest.Cards.ToList()))
            {
                Next?.Handle(request);
            }
            else
            {
                handRequest.Hand = Hand.ThreeOfAKind;
            }
        }

        private bool HasThreeOfKind(List<Card> cards)
        {
            var hasThree = HandHandlerHelper.HasAmountOfCards(cards, 3, 1);
            var hasTwoAndJoker = HandHandlerHelper.HasAmountOfCards(cards, 2, 1) && HandHandlerHelper.HasJoker(cards);
            var hasJokers = HandHandlerHelper.HasJokers(cards, 2);

            return hasThree || hasTwoAndJoker || hasJokers;
        }
    }
}