namespace NorthWind.Sales.Controllers
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddNorthWindSalesControllerServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateOrderController, CreateOrderController>();

            return services;
        }
    }
}