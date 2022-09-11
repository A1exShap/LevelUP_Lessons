using Microsoft.Extensions.DependencyInjection;
using Services.Implementation;
using DataAccess;

namespace Services
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IItemsService, ItemsService>();

            services.RegisterRepositories();
        }
    }
}
