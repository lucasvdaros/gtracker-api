using GTracker.Domain.Core.Events;

namespace GTracker.Domain.Core.Interface
{
    public interface IHandler<in T> where T : Message
    {
        void Handle(T message);
    }
}