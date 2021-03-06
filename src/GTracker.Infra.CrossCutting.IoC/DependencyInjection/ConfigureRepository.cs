using GTracker.Infra.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using GTracker.Domain.Interface.Repository;
using GTracker.Infra.Data.Repository;
using GTracker.Domain.Core.Interface;
using GTracker.Infra.Data.Uow;
using GTracker.Infra.Data.Test;

namespace GTracker.Infra.CrossCutting.IoC.DependencyInjection
{
    public static class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var mySqlConnectionStr = configuration.GetConnectionString("DefaultConnection");            

            serviceCollection.AddDbContext<GTrackerContext>(
                options => options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr))
            );

            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<GTrackerContext>();
            
            serviceCollection.AddScoped<IUserRepository, UserRepository>();
            serviceCollection.AddScoped<IFriendRepository, FriendRepository>();
            serviceCollection.AddScoped<IGameRepository, GameRepository>();
            serviceCollection.AddScoped<ILoanRepository, LoanRepository>();
            serviceCollection.AddScoped<ILoanGameRepository, LoanGameRepository>();

            serviceCollection.AddTransient<SeedDataService>();            
        }
    }
}