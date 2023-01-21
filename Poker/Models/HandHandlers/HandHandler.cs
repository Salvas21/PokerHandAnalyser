#nullable enable
namespace Poker.Models.HandHandlers
{
    public abstract class HandHandler : IHandler
    {
        protected HandHandler? Next;
        
        public void SetNext(IHandler next)
        {
            Next = (HandHandler) next;
        }

        public abstract void Handle(IHandlerRequest request);
    }
}