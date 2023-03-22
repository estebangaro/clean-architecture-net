namespace NorthWind.Sales.UseCases.CreateOrder
{
    public class CreateOrderIntercator : ICreateOrderInputPort
    {
        readonly ICreateOrderOutputPort outputPort;
        readonly INorthWindSalesCommandsReposiroty northWindSalesCommandsReposiroty;

        public CreateOrderIntercator(ICreateOrderOutputPort outputPort,
            INorthWindSalesCommandsReposiroty northWindSalesCommandsReposiroty)
        {
            this.outputPort = outputPort;
            this.northWindSalesCommandsReposiroty = northWindSalesCommandsReposiroty;
        }

        public async ValueTask Handle(BusinessObjects.DTOs.CreateOrder.CreateOrder order)
        {
            OrderAggregate Order = new OrderAggregate
            {
                CustomerId = order.CustomerId,
                ShipAddress = order.ShipAddress,
                ShipCity = order.ShipCity,
                ShipCountry = order.ShipCountry,
                ShipPostalCode = order.ShipPostalCode
            };

            foreach (var od in order.OrderDetails)
            {
                Order.AddDetail(od.ProductId, od.UnitPrice, od.Quantity);
            }

            await northWindSalesCommandsReposiroty.CreateOrder(Order);
            await northWindSalesCommandsReposiroty.SaveChanges();
            await outputPort.Handle(Order.Id);
        }
    }
}