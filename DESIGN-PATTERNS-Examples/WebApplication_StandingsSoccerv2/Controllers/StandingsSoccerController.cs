using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoccerStandings.Requests;

namespace WebApplication_StandingsSoccerv1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StandingsSoccerController : ControllerBase
    {
        IMediator _mediator;

        public StandingsSoccerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "GetStandingSoccer")]
        public async Task<IActionResult> Post(GetStandingRequest getStandingRequest)
        {
            try
            {
                return Ok(await _mediator.Send(getStandingRequest));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}