using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatRDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EdiTransactionsLogController : ControllerBase
    {
        IPublisher mediator;
        public EdiTransactionsLogController(IPublisher mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Register([FromBody] EDI_REQUESTS.CreateEdiTransactionLog request)
        {
            await mediator.Publish(request);

            return Ok();
        }
    }
}