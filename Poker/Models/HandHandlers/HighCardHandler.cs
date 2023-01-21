namespace Poker.Models.HandHandlers
{
    public class HighCardHandler : HandHandler
    {
        public override void Handle(IHandlerRequest request)
        {
            ((HandRequest) request).Hand = Hand.HighCard;
        }
    }
}