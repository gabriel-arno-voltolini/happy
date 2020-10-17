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
    }
}