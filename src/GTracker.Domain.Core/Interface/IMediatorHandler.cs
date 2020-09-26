using System.Threading.Tasks;
using GTracker.Domain.Core.Commands;
using GTracker.Domain.Core.Events;

namespace GTracker.Domain.Core.Interface
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}