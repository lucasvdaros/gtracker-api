using GTracker.Domain.Core.Events;

namespace GTracker.Domain.Core.Interface
{
    public interface IEventStore
    {
        void Save<T>(T theEvent) where T : Event;
    }
}