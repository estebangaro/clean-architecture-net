using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatRDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EdiTransactionsController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IPublisher publisher;
        public EdiTransactionsController(IMediator mediator, IPublisher publisher)
        {
            this.mediator = mediator;
            this.publisher = publisher;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Register([FromBody] EdiRequests.CreateEdiTransaction request)
        {
            var result = await mediator.Send(request);
            await publisher.Publish(new EDI_REQUESTS.CreateEdiTransactionLog
            {
                Message = $"Transacción #{result} registrada!!",
                Type = $"EdiTransaction-{request.Type}"
            });

            return Ok($"Transacción #{result} registrada!!");
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] string Id)
        {
            await mediator.Send(new EdiRequests.DeleteEdiTransaction
            {
                Id = int.Parse(Id)
            });
            await publisher.Publish(new EDI_REQUESTS.CreateEdiTransactionLog
            {
                Message = $"Transacción #{Id} eliminada!!",
                Type = $"EdiTransaction-DELETE"
            });

            return Ok($"Transacción #{Id} eliminada!!");
        }
    }
}