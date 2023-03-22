namespace NorthWind.Sales.BusinessObjects.Aggregates
{
    public class OrderAggregate : Order
    {
        readonly List<OrderDetail> OrderDetailsField = new();
        public IReadOnlyCollection<OrderDetail> OrderDetails { get => OrderDetailsField; }

        public void AddDetail(OrderDetail orderDetail)
        {
            var ExistingOrderDetail =
                OrderDetailsField.FirstOrDefault(od => od.ProductId == orderDetail.ProductId);

            if (ExistingOrderDetail != default)
            {
                var quantity = ExistingOrderDetail.Quantity + orderDetail.Quantity;
                if (OrderDetailsField.Remove(ExistingOrderDetail))
                {
                    OrderDetail tempOrderDetail = new()
                    {
                        ProductId = orderDetail.ProductId,
                        Quantity = (short)quantity,
                        UnitPrice = orderDetail.UnitPrice
                    };
                    OrderDetailsField.Add(tempOrderDetail);
                }
                else
                {
                    //TODO: Implementar excepción personalizada.
                    throw new InvalidOperationException("");
                }
            }
            else
            {
                OrderDetailsField.Add(orderDetail);
            }
        }

        public void AddDetail(int productId, decimal UnitPrice, short quantity) =>
            AddDetail(new OrderDetail(productId, UnitPrice, quantity));
    }
}