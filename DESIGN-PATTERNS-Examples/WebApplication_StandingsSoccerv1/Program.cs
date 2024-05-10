
using Mediator.DI;
using System.Reflection;

namespace WebApplication_StandingsSoccerv1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var assemblyNames = Assembly.GetExecutingAssembly().GetReferencedAssemblies();

            //builder.Services.AddMediator("SoccerStandings_BING, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");
            builder.Services.AddMediator("SoccerStandings_API, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
