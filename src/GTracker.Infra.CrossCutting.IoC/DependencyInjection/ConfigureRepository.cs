using GTracker.Infra.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using GTracker.Domain.Interface.Repository;
using GTracker.Infra.Data.Repository;

namespace GTracker.Infra.CrossCutting.IoC.DependencyInjection
{
    public static class ConfigureRepository
    {
         public static void ConfigureDependenciesRepository(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<GTrackerContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );

            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));            
        }
    }
}