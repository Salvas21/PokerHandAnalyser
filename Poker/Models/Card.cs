using System;

namespace Poker.Models
{
    public class Card
    {
        public Rank? Rank { get; private set; }
        public Suit? Suit { get; private set; }
        public RankValue? Power { get; private set; }

        public Card(Rank rank, Suit suit)
        {
            Rank = rank;
            Suit = suit;
            Power = FindPower();
        }

        public Card(RankValue power, Suit suit)
        {
            Power = power;
            Suit = suit;
            Rank = FindRank();
        }

        public Card(char rank, char suit)
        {
            if (string.Empty + rank + suit != "JK")
            {
                CreateCard(rank, suit);
            }
            else
            {
                CreateJoker();
            }
        }
        
        public bool IsJoker()
        {
            return !Rank.HasValue && !Suit.HasValue;
        }
        
        /// <summary>
        /// Determine whether the current Card is strictly equals to the other Card (Rank and Suit are equals).
        /// </summary>
        public bool StrictEquals(Card other)
        {
            return Rank == other.Rank && Suit == other.Suit;
        }

        /// <summary>
        /// Determine whether the current Card has the same Suit as the other Card.
        /// </summary>
        public bool EqualsSuit(Card other)
        {
            return Suit == other.Suit;
        }
        
        /// <summary>
        /// Determine whether the current Card has the same Rank as the other object of type Card.
        /// </summary>
        public override bool Equals(object? obj)
        {
            return obj is Card card && Rank == card.Rank;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(string.Empty + Rank + Suit);
        }

        private void CreateCard(char rank, char suit)
        {
            Rank = (Rank) rank;
            Suit = (Suit) suit;
            Power = FindPower();
        }
        
        private RankValue? FindPower()
        {
            return Rank.HasValue ? (RankValue)Enum.Parse(typeof(RankValue), Enum.GetName(Rank.Value)!) : null;
        }

        private Rank? FindRank()
        {
            return Power.HasValue ? (Rank)Enum.Parse(typeof(Rank), Enum.GetName(Power.Value)!) : null;
        }

        private void CreateJoker()
        {
            
        }

    }
}