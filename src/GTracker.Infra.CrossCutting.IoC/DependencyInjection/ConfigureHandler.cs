using GTracker.Domain.CommandHandler;
using GTracker.Domain.Commands.Friend;
using GTracker.Domain.Commands.Game;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace GTracker.Infra.CrossCutting.IoC.DependencyInjection
{
    public static class ConfigureHandler
    {
        public static void ConfigureDependenciesHandler(this IServiceCollection serviceCollection)
        {   
            // Friend
            serviceCollection.AddScoped<IRequestHandler<RegisterNewFriendCommand, bool>, FriendCommandHandler>();
            serviceCollection.AddScoped<IRequestHandler<UpdateFriendCommand, bool>, FriendCommandHandler>();

            // Game
            serviceCollection.AddScoped<IRequestHandler<RegisterNewGameCommand, bool>, GameCommandHandler>();
            serviceCollection.AddScoped<IRequestHandler<UpdateGameCommand, bool>, GameCommandHandler>();            
        }
    }
}