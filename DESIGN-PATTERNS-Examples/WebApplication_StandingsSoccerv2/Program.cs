using MediatR;
using SoccerStandings.Classes;
using SoccerStandings.Requests;
using SoccerStandingsv2.Behaviours;
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
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.Load("SoccerStandings_APIv2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")));
            builder.Services.AddTransient(typeof(IPipelineBehavior<GetStandingRequest, IEnumerable<StandingTeamInformation>>),
                typeof(StandingRequestPipelineBehaviour));
            builder.Services.AddTransient(typeof(IPipelineBehavior<GetStandingRequest, IEnumerable<StandingTeamInformation>>),
                typeof(StandingRequestCompetitionIdPipelineBehaviour));

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
