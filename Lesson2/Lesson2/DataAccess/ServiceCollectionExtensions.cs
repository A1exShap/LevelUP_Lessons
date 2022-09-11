using Microsoft.Extensions.DependencyInjection;
using DataAccess.Repositories;
using DataAccess.Repositories.Implementation;

namespace DataAccess
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IItemsRepository, ItemsRepository>();
            services.AddScoped<IItemPropertyValueRepository, ItemPropertyValueRepository>();
        }
    }
}
