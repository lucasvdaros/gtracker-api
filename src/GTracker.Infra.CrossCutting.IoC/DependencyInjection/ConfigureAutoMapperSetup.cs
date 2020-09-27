using AutoMapper;
using GTracker.Infra.CrossCutting.IoC.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace GTracker.Infra.CrossCutting.IoC.DependencyInjection
{
    public static class ConfigureAutoMapperSetup
    {
       public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                 cfg.AddProfile(new DtoToCommandProfile());
                 cfg.AddProfile(new CommandToEntityProfile());
                 cfg.AddProfile(new EntityToDtoProfile());                
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        } 
    }
}