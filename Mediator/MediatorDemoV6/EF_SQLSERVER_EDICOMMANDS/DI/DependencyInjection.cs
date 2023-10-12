using EF_SQLSERVER_EDI_COMMANDS.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EF_SQLSERVER_EDI_COMMANDS
{
    public static class DependencyInjection
    {
        public static void Add_EFSQLSERVER_EDICOMMANDS(this IServiceCollection services)
        {
            string connectionString;
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            if (environment == "Development")
            {
                connectionString = "Server=.;Database=Pruebas;Trusted_Connection=True;TrustServerCertificate=True;";
            }
            else
            {
                throw new NotSupportedException("No se ha configurado la cadena de conexión productiva");
            }

            services.AddDbContext<EdiContext>(options => options.UseSqlServer(connectionString));
        }
    }
}