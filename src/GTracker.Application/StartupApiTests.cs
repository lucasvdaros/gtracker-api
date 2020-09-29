using GTracker.Application.Filter;
using GTracker.Infra.CrossCutting.IoC.DependencyInjection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GTracker.Application
{
    public class StartupApiTests
    {
        public IConfiguration Configuration { get; }

        public StartupApiTests(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureDependenciesService();

            services.ConfigureDependenciesRepository(Configuration);

            services.ConfigureDependenciesHandler();

            services.AddAutoMapperSetup();

            services.AddAuthJwt(Configuration);

            services.AddMediatR(typeof(Startup));
            
            services.AddControllers();

            services.AddSwaggerSetup();

            services.AddMvc(options => options.Filters.Add<NotificationFilter>())
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}