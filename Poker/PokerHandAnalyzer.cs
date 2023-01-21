using System.Collections.Generic;
using System.Linq;
using Poker.Models;

namespace Poker
{
    public class PokerHandAnalyzer
    {
        public Hand AnalyzeHand(string[] hand)
        {
            hand = ConvertToUpper(hand);
            HandValidator.Validate(hand, true);
            var cards = CardGenerator.Generate(hand);
            var request = new HandRequest(cards);
            
            HandChecker.CheckHand(request);

            return request.Hand;
        }

        private string[] ConvertToUpper(IEnumerable<string> hand)
        {
            return hand.Select(s => s.ToUpper()).ToArray();
        }
    }
}
