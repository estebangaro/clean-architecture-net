namespace ConsoleApp_Notifications_Eventsv1
{
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Construir el Host que contiene el proveedor de servicios (DI Container)
            using (var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    // 2. Registrar los servicios con ciclo de vida Transient
                    services.AddTransient<Entities.INotificacionHandler, Models.NotificationHandlers.NotificationHandler1>();
                    services.AddTransient<Entities.INotificacionHandler, Models.NotificationHandlers.NotificationHandler2>();
                    services.AddTransient<Entities.INotificacionHandler, Models.NotificationHandlers.NotificationHandler3>();
                    services.AddTransient<Entities.IMediator, Models.MessageHubMediator>();
                })
                .Build())
            {
                // 3. Solicitar una instancia del servicio al contenedor de DI
                Entities.IMediator mediator = host.Services.GetRequiredService<Entities.IMediator>();

                Infrastructure.PersistenceService persistenceService = new Infrastructure.PersistenceService(mediator);
                persistenceService.Save();

                host.Run();

                Console.WriteLine($"Finalizando ejecución...");
            }
        }
    }
}