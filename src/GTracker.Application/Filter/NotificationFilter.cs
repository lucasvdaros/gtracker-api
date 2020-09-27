using System.Net;
using System.Threading.Tasks;
using GTracker.Domain.Core.Notification;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace GTracker.Application.Filter
{
    public class NotificationFilter : IAsyncResultFilter
    {
        private readonly DomainNotificationHandler _notificationContext;

        public NotificationFilter(INotificationHandler<DomainNotification> notifications)
        {
            _notificationContext = (DomainNotificationHandler)notifications;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (_notificationContext.HasNotifications)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.HttpContext.Response.ContentType = "application/json";

                var notifications = JsonConvert.SerializeObject(_notificationContext.Notifications);
                await context.HttpContext.Response.WriteAsync(notifications);

                return;
            }

            await next();
        }
    }

}