using Mediator.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Mediator.DI
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMediator(this IServiceCollection services, string assemblyName)
        {
            services.AddSingleton<IMediator>(serviceProvider =>
                new Models.Mediator(Assembly.Load(assemblyName))
            );

            return services;
        }
    }
}