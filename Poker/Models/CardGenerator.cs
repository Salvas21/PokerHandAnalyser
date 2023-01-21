using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker.Models
{
    public static class CardGenerator
    {
        private const int RankIndex = 0;
        private const int SuitIndex = 1;
        public static IEnumerable<Card> Generate(IEnumerable<string> hand)
        {
            return hand.Select(card => new Card(card[RankIndex], card[SuitIndex])).ToList();
        }
    }
}