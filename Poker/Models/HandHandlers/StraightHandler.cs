using System.Collections.Generic;
using System.Linq;

namespace Poker.Models.HandHandlers
{
    public class StraightHandler: HandHandler
    {
        public override void Handle(IHandlerRequest request)
        {
            var handRequest = (HandRequest) request;
            
            if (!HasStraight(handRequest.Cards.ToList()))
            {
                Next?.Handle(request);
            }
            else
            {
                handRequest.Hand = Hand.Straight;
            }
        }

        private bool HasStraight(List<Card> cards)
        {
            return HandHandlerHelper.HasFollowingOfCards(cards) || HasHighAceStraight(cards);
        }

        private bool HasHighAceStraight(List<Card> cards)
        {
            var template = HandHandlerHelper.GenerateRoyalCards();
            var amount = HandHandlerHelper.GetContainedAmount(cards, template);
            var jokers = HandHandlerHelper.HowMuchJokers(cards);
            return amount + jokers == 5;
        }
    }
}