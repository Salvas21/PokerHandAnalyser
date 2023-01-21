using Poker.Models.HandHandlers;

namespace Poker.Models
{
    public static class HandChecker
    {
        private static HandHandler _royalFlush = new RoyalFlushHandler();
        private static HandHandler _straightFlush = new StraightFlushHandler();
        private static HandHandler _fourOfKind = new FourOfKindHandler();
        private static HandHandler _fullHouse = new FullHouseHandler();
        private static HandHandler _flush = new FlushHandler();
        private static HandHandler _straight = new StraightHandler();
        private static HandHandler _threeOfKind = new ThreeOfKindHandler();
        private static HandHandler _twoPair = new TwoPairHandler();
        private static HandHandler _pair = new PairHandler();
        private static HandHandler _high = new HighCardHandler();
        
        public static void CheckHand(IHandlerRequest request)
        { 
            ChainHandlers();
            Handle(request);
        }

        private static void ChainHandlers()
        {
            _pair.SetNext(_high);
            _twoPair.SetNext(_pair);
            _threeOfKind.SetNext(_twoPair);
            _straight.SetNext(_threeOfKind);
            _flush.SetNext(_straight);
            _fullHouse.SetNext(_flush);
            _fourOfKind.SetNext(_fullHouse);
            _straightFlush.SetNext(_fourOfKind);
            _royalFlush.SetNext(_straightFlush);
        }

        private static void Handle(IHandlerRequest request)
        {
            _royalFlush.Handle(request);
        }
    }
}