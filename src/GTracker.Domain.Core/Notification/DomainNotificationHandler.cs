using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace GTracker.Domain.Core.Notification
{
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>
    {
        private readonly List<DomainNotification> _notifications;
        public IReadOnlyCollection<DomainNotification> Notifications => _notifications;
        public bool HasNotifications => _notifications.Any();


        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        public Task Handle(DomainNotification message, CancellationToken cancellationToken)
        {
            _notifications.Add(message);

            return Task.CompletedTask;
        }

        public Task Handle(IList<DomainNotification> notifications, CancellationToken cancellationToken)
        {
            _notifications.AddRange(notifications);
            
             return Task.CompletedTask;
        }

        public virtual List<DomainNotification> GetNotifications()
        {
            return _notifications;
        }
    }
}