using GTracker.Domain.Core.Interface;
using GTracker.Domain.Core.Notification;
using GTracker.Domain.Interface.Service;
using GTracker.Infra.CrossCutting.Bus;
using GTracker.Service;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace GTracker.Infra.CrossCutting.IoC.DependencyInjection
{
    public static class ConfigureService
    {
        public static void ConfigureDependenciesService(this IServiceCollection serviceCollection)
        {   
            // Domain Bus (Mediator)
            serviceCollection.AddScoped<IMediatorHandler, InMemoryBus>();

            // Services
            serviceCollection.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            serviceCollection.AddScoped<IPasswordService, PasswordService>();
            serviceCollection.AddScoped<ITokenService, TokenService>();
            serviceCollection.AddScoped<IUserService, UserService>();
        }
    }
}