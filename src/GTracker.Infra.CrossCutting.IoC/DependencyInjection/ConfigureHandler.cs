using GTracker.Domain.CommandHandler;
using GTracker.Domain.Commands.Friend;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace GTracker.Infra.CrossCutting.IoC.DependencyInjection
{
    public static class ConfigureHandler
    {
        public static void ConfigureDependenciesHandler(this IServiceCollection serviceCollection)
        {             
            serviceCollection.AddScoped<IRequestHandler<RegisterNewFriendCommand, bool>, FriendCommandHandler>();
            serviceCollection.AddScoped<IRequestHandler<UpdateFriendCommand, bool>, FriendCommandHandler>();
        }
    }
}