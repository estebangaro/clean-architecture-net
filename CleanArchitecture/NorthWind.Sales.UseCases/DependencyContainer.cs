namespace NorthWind.Sales.UseCases
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddUseCasesServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateOrderInputPort, CreateOrderIntercator>();

            return services;
        }
    }
}