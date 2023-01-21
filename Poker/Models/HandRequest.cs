using System.Collections;
using System.Collections.Generic;
using Poker.Models.HandHandlers;

namespace Poker.Models
{
    public class HandRequest : IHandlerRequest
    {
        public IEnumerable<Card> Cards { get; }
        public Hand Hand { get; set; }
        
        public HandRequest(IEnumerable<Card> cards)
        {
            Cards = cards;
            Hand = Hand.HighCard;
        }
    }
}