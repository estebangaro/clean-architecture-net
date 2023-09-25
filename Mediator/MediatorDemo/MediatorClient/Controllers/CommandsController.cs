using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace MediatorClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        readonly IMediator Mediator;
        public CommandsController(IMediator mediator) =>
        Mediator = mediator;

        [HttpPost]
        [Route("edi/transactions/create")]
        public async Task<IActionResult> Create(string name, string type, string description)
        {
            int Id = await Mediator.Send(
                new EdiRequests.CreateEdiTransaction { Name = name, Type = type, Description = description });
            return Ok(Id);
        }

        [HttpDelete]
        [Route("edi/transactions/delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new EdiRequests.DeleteEdiTransaction { Id = id });
            return Ok($"Id {id} eliminado!!!");
        }
    }
}
