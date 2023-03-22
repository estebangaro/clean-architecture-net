namespace NorthWind.Sales.Presenters
{
    public class CreateOrderPresenter : ICreateOrderPresenter
    {
        public int OrderId { get; private set; }

        public ValueTask Handle(int orderId)
        {
            OrderId = orderId;

            return ValueTask.CompletedTask;
        }
    }
}