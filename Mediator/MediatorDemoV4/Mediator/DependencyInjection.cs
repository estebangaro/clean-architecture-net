using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Mediator
{
    public static class DependencyInjection
    {
        public static void AddMediator(this IServiceCollection services, Assembly handlerAssembly)
        {
            services.AddSingleton<IMediator>(sp =>
            {
                return new Mediator(handlerAssembly);
            });
        }
    }
}