namespace NorthWind.Sales.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddNortWindSalesServices(this IServiceCollection services,
            IConfiguration configuration, string connectionStringName)
        {
            services.AddNorthWindSalesControllerServices();
            services.AddUseCasesServices();
            services.AddRepositoryServices(configuration, connectionStringName);
            services.AddPresenterServices();

            return services;
        }
    }
}