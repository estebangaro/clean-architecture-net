namespace NorthWind.Sales.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalesController : ControllerBase
    {
        ICreateOrderController _createOrderController;

        public SalesController(ICreateOrderController createOrderController)
        {
            _createOrderController = createOrderController;
        }

        [HttpPost]
        public async Task<int> CreateOrder(CreateOrder order)
        {
            return await _createOrderController.CreateOrder(order);
        }
    }
}