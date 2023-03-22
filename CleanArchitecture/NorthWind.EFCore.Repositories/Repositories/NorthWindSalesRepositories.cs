namespace NorthWind.EFCore.Repositories.Repositories
{
    public class NorthWindSalesRepositories : INorthWindSalesCommandsReposiroty
    {
        readonly NorthwindSalesContext _context;

        public NorthWindSalesRepositories(NorthwindSalesContext context)
        {
            _context = context;
        }

        public async ValueTask CreateOrder(OrderAggregate order)
        {
            await _context.AddAsync(order);

            foreach (var orderDetail in order.OrderDetails)
            {
                await _context.AddAsync(new OrderDetail
                {
                    Order = order,
                    ProductId = orderDetail.ProductId,
                    Quantity = orderDetail.Quantity,
                    UnitPrice = orderDetail.UnitPrice
                });
            }
        }

        public async ValueTask SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}