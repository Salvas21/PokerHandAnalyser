namespace Poker.Models.HandHandlers
{
    public interface IHandler
    {
        public void SetNext(IHandler next);
        public void Handle(IHandlerRequest request);
    }
}