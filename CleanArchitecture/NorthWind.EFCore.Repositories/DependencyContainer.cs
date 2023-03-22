namespace NorthWind.EFCore.Repositories
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services,
            IConfiguration configuration, string connectionStringName)
        {
            services.AddDbContext<NorthwindSalesContext>(
                    options => options.UseSqlServer(configuration.GetConnectionString(connectionStringName))
                );
            services.AddScoped<INorthWindSalesCommandsReposiroty, NorthWindSalesRepositories>();

            return services;
        }
    }
}