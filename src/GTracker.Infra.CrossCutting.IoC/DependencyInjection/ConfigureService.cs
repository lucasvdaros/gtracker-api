using GTracker.Domain.Core.Notification;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace GTracker.Infra.CrossCutting.IoC.DependencyInjection
{
    public static class ConfigureService
    {
        public static void ConfigureDependenciesService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
        }
    }
}