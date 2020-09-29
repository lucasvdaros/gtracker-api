using GTracker.Domain.CommandHandler;
using GTracker.Domain.Commands.Friend;
using GTracker.Domain.Commands.Game;
using GTracker.Domain.Commands.Loan;
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

            // Loan
            serviceCollection.AddScoped<IRequestHandler<RegisterNewLoanCommand, bool>, LoanCommandHandler>();
            serviceCollection.AddScoped<IRequestHandler<FinishLoanCommand, bool>, LoanCommandHandler>();            
        }
    }
}