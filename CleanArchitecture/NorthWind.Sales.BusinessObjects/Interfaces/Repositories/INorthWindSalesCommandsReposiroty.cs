namespace NorthWind.Sales.BusinessObjects.Interfaces.Repositories
{
    public interface INorthWindSalesCommandsReposiroty : IUnitOfWork
    {
        ValueTask CreateOrder(OrderAggregate order);
    }
}