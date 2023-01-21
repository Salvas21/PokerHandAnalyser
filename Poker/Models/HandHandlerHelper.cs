using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker.Models
{
    public static class HandHandlerHelper
    {
        public static bool HasJoker(IEnumerable<Card> cards)
        {
            return cards.Any(c => c.IsJoker());
        }

        public static bool HasJokers(IEnumerable<Card> cards, int amount)
        {
            return cards.Count(c => c.IsJoker()) == amount;
        }

        public static int HowMuchJokers(IEnumerable<Card> cards)
        {
            return cards.Count(c => c.IsJoker());
        }

        public static bool HasAmountOfCards(IList<Card> cards, int amount, int times)
        {
            var ranksDictionary = FindRanksDictionary(cards);
            return ranksDictionary.Count(keyValuePair => keyValuePair.Value == amount) == times;
        }

        public static bool HasSameSuit(IList<Card> cards)
        {
            var card = FindCardWithSuit(cards);
            var noJokers = cards.Where(c => !c.IsJoker());
            return noJokers.All(c => c.EqualsSuit(card));
        }

        public static bool HasFollowingOfCards(IList<Card> originalCards)
        {
            var cards = PrepareCardsForStraight(originalCards);
            var jokerAmount = HowMuchJokers(originalCards);
            if (jokerAmount + cards.Count < originalCards.Count) return false;
            
            for (int i = 0; i < cards.Count - 1; i++)
            {
                if (cards[i].Power + 1 != cards[i + 1].Power)
                {
                    if (jokerAmount <= 0) return false;
                    var list = GenerateListWithNewCard(cards[i], cards, jokerAmount);
                    return HasFollowingOfCards(list);
                }
            }
            return true;
        }

        public static int GetContainedAmount(IList<Card> cards, IList<Card> template)
        {
            return template.Count(cards.Contains);
        }

        public static IList<Card> GenerateRoyalCards()
        {
            var suit = Suit.Diamonds;
            return new List<Card>
            {
                new(Rank.Ace, suit),
                new(Rank.Ten, suit),
                new(Rank.Jack, suit),
                new(Rank.Queen, suit),
                new(Rank.King, suit)
            };
        }

        private static IList<Card> GenerateListWithNewCard(Card previousCard, IList<Card> cards, int jokerAmount)
        {
            var power = (RankValue)(previousCard.Power + 1);
            var suit = (Suit)previousCard.Suit;
            var list = cards.Append(new Card(power, suit));
            
            list = jokerAmount - 1 > 0 ? list.Append(new Card('J', 'K')) : list;
            
            return list.ToList();
        }

        private static Card FindCardWithSuit(IList<Card> cards)
        {
            return cards.Where(c => !c.IsJoker()).ElementAt(0);
        }
        
        private static IList<Card> SortCards(IList<Card> cards)
        {
            return cards.OrderBy(c => c.Power).ToList();
        }

        private static IList<Card> RemoveJokers(IList<Card> cards)
        {
            return cards.Where(c => !c.IsJoker()).ToList();
        }

        private static IList<Card> DistinctCards(IList<Card> cards)
        {
            return cards.Distinct().ToList();
        }
        
        private static IList<Card> PrepareCardsForStraight(IList<Card> cards)
        {
            return SortCards(DistinctCards(RemoveJokers(cards)));
        }

        private static IDictionary<Rank, int> FindRanksDictionary(IList<Card> cards)
        {
            var ranks = new Dictionary<Rank, int>();
            foreach (var card in cards)
            {
                if (card.Rank != null && !ranks.TryAdd((Rank)card.Rank, 1))
                {
                    ranks[(Rank)card.Rank] = ranks.GetValueOrDefault((Rank)card.Rank) + 1;
                }
            }
            return ranks;
        }
        
    }
}