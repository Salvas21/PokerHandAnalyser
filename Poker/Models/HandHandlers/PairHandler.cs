using System.Collections.Generic;
using System.Linq;

namespace Poker.Models.HandHandlers
{
    public class PairHandler : HandHandler
    {
        public override void Handle(IHandlerRequest request)
        {
            var handRequest = (HandRequest) request;
            
            if (!HasPair(handRequest.Cards.ToList()))
            {
                Next?.Handle(request);
            }
            else
            {
                handRequest.Hand = Hand.Pair;
            }
        }

        private bool HasPair(IList<Card> cards)
        {
            return HandHandlerHelper.HasAmountOfCards(cards, 2, 1) || HandHandlerHelper.HasJoker(cards);
        }
    }
}