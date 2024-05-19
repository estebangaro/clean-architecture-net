using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebApplication_SoccerStandings.DbContext;
using WebApplication_SoccerStandings.Interfaces;
using WebApplication_SoccerStandings.Models;
namespace WebApplication_SoccerStandings
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

            builder.Services.AddDbContext<TestsContext>(dbcob => dbcob.UseSqlServer(
                connectionString: builder.Configuration.GetConnectionString("tests_db_conn")));

            builder.Services.AddScoped<ISoccerTeamContext, SoccerTeamContext>();

            builder.Services.AddMediatR(cnfg => cnfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

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
