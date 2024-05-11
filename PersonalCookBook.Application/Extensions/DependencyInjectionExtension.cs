using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Net.NetworkInformation;

namespace PersonalCookBook.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationHandlers(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));
        }
    }
}
