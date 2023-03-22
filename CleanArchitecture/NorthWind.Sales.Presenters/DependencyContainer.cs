

namespace NorthWind.Sales.Presenters
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddPresenterServices(this IServiceCollection services)
        {
            services.AddScoped<CreateOrderPresenter>();
            services.AddScoped<ICreateOrderOutputPort>(servicesProvider =>
                servicesProvider.GetService<CreateOrderPresenter>());
            services.AddScoped<ICreateOrderPresenter>(servicesProvider =>
                servicesProvider.GetService<CreateOrderPresenter>());

            return services;
        }
    }
}