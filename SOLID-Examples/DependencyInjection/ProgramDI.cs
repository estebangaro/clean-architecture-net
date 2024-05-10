using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DependencyInjection
{
    public class ProgramDI
    {
        public static IHost BuildDependencyInjectionContainer()
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();

            builder.Services.AddTransient(typeof(Interfaces.ILogger), typeof(Services.Loggers.LoggerConsole));
            builder.Services.AddTransient(typeof(Interfaces.ILogger), typeof(Services.Loggers.LoggerFile));
            builder.Services.AddTransient(typeof(Interfaces.ILoggerService), typeof(Services.LoggerServices.SingleLoggerService));
            builder.Services.AddTransient(typeof(Interfaces.IGuidService), typeof(Services.Guid36BytesService));

            return builder.Build();
        }
    }
}
