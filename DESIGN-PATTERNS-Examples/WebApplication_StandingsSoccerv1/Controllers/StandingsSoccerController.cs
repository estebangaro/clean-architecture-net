using Mediator.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SoccerStandings.Classes;
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
        public async Task<IEnumerable<StandingTeamInformation>> Post(GetStandingRequest getStandingRequest)
        {
            return await _mediator.Send(getStandingRequest);
        }
    }
}