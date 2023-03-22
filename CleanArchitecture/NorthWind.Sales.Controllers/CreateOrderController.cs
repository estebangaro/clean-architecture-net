namespace NorthWind.Sales.Controllers
{
    public class CreateOrderController : ICreateOrderController
    {
        readonly ICreateOrderInputPort _createOrderInputPort;
        readonly ICreateOrderPresenter _createOrderPresenter;

        public CreateOrderController(ICreateOrderInputPort createOrderInputPort, ICreateOrderPresenter createOrderPresenter)
        {
            _createOrderInputPort = createOrderInputPort;
            _createOrderPresenter = createOrderPresenter;
        }

        public async ValueTask<int> CreateOrder(CreateOrder order)
        {
            await _createOrderInputPort.Handle(order);
            return _createOrderPresenter.OrderId;
        }
    }
}