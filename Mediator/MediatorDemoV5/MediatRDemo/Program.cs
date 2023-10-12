using EF_SQLSERVER_EDI_COMMANDS;

namespace MediatRDemo
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

            var dalName = Environment.GetEnvironmentVariable("DAL_NAME");

            if (dalName == "EF_SQLSERVER_EDI_COMMANDS")
                builder.Services.Add_EFSQLSERVER_EDICOMMANDS();

            builder.Services.AddMediatR(mrsc =>
            {
                if (string.IsNullOrEmpty(dalName))
                    mrsc.RegisterServicesFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
                else
                    mrsc.RegisterServicesFromAssembly(System.Reflection.Assembly.Load(dalName));
            });

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