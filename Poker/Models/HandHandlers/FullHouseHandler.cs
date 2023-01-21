using System.Collections.Generic;
using System.Linq;

namespace Poker.Models.HandHandlers
{
    public class FullHouseHandler : HandHandler
    {
        public override void Handle(IHandlerRequest request)
        {
            var handRequest = (HandRequest) request;
            
            if (!HasFullHouse(handRequest.Cards.ToList()))
            {
                Next?.Handle(request);
            }
            else
            {
                handRequest.Hand = Hand.FullHouse;
            }
        }

        private bool HasFullHouse(List<Card> cards)
        {
            var hasThree = HandHandlerHelper.HasAmountOfCards(cards, 3, 1);
            var hasTwo = HandHandlerHelper.HasAmountOfCards(cards, 2, 1);
            var fullHouse = hasThree && hasTwo;

            var hasTwoPairs = HandHandlerHelper.HasAmountOfCards(cards, 2, 2);
            var hasJoker = HandHandlerHelper.HasJoker(cards);

            return fullHouse || hasTwoPairs && hasJoker;
        }
    }
}