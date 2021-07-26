using HandsOnTestGoDigital.Core.Interfaces.Repositories;
using HandsOnTestGoDigital.Infraestructure.Data.APIMovie;
using Microsoft.Extensions.DependencyInjection;

namespace HandsOnTestGoDigital.Infraestructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}
