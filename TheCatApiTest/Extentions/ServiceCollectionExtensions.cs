using TheCatApiTest.Services;
using Interfaces.Repository;
using Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using Repository;

namespace TheCatApiTest.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDependencyInjections(this IServiceCollection services)
        {
            services.AddTransient<ICatApiService, CatApiService>();
            services.AddTransient<ICatApiRepository, CatApiRepository>();
        }
    }
}
