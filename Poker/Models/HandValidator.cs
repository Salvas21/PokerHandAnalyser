using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker.Models
{
    public static class HandValidator
    {
        private const string JokerString = "JK";
        private const int RankIndex = 0;
        private const int SuitIndex = 1;

        public static void Validate(string[] hand, bool withJokers)
        {
            VerifyLength(hand);
            if (withJokers) hand = RemoveJokers(hand);
            VerifyDupes(hand);
            VerifyRanks(hand);
            VerifySuits(hand);
        }
        
        private static void VerifyLength(string[] hand)
        {
            if (hand.Length != 5)
            {
                throw new ArgumentException("Hand invalid, wrong number of cards (should have 5)");
            }
        }

        private static void VerifyDupes(string[] hand)
        {
            if (new HashSet<string>(hand).Count != hand.Length)
            {
                throw new ArgumentException("Hand invalid, duplicate cards found");
            }
        }

        private static string[] RemoveJokers(string[] hand)
        {
            return hand.Where(s => s != JokerString).ToArray();
        }

        private static void VerifyRanks(string[] hand)
        {
            var ranks = hand.Select(s => s[RankIndex]);
            if (ranks.Any(r => !Enum.IsDefined((Rank) r)))
            {
                throw new ArgumentException("Hand invalid, non-existing rank");
            }
        }
        
        private static void VerifySuits(string[] hand)
        {
            var suits = hand.Select(s => s[SuitIndex]);
            if (suits.Any(s => !Enum.IsDefined((Suit) s)))
            {
                throw new ArgumentException("Hand invalid, non-existing suit");
            }
        }
    }
}