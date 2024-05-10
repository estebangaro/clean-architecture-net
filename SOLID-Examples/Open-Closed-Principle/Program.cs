using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Open_Closed_Principle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (IHost host = DependencyInjection.ProgramDI.BuildDependencyInjectionContainer())
            {
                Console.WriteLine("Iniciando ejecución de Program...");
                Run(host);
                host.Run();
            }
        }

        static void Run(IHost host)
        {
            using (IServiceScope serviceScope = host.Services.CreateScope())
            {
                var guidService = serviceScope.ServiceProvider.GetRequiredService<Interfaces.IGuidService>();
                var guid = guidService.Build();
                Console.WriteLine("Se ha generado el GUID correctamente...");
            }
        }
    }
}
