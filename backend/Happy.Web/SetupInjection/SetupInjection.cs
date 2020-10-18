using AutoMapper;
using Happy.Application.AutoMapper;
using Happy.Application.Interfaces.Services;
using Happy.Application.Services;
using Happy.Domain.Interfaces.Repositories;
using Happy.Infra.Repositories.EntityRepositories;
using Microsoft.Extensions.DependencyInjection;

namespace Happy.Web.SetupInjection
{
    public static class SetupInjection
    {
        public static void SetupServicesDependencies(this IServiceCollection services)
        {
            services.AddScoped<IOrphanageService, OrphanageService>();
        }

        public static void SetupRepositoriesDependencies(this IServiceCollection services)
        {
            services.AddScoped<IOrphanageRepository, OrphanageRepository>();
        }

        public static void SetupAutoMapperDependecies(this IServiceCollection services)
        {
            var config = new MapperConfiguration(c =>
            {
                c.AddProfile(new AutoMapperProfile());
            });

            services.AddSingleton(config.CreateMapper());
        }
    }
}