using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SoccerTriviaApp_Piloto.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SoccerStatisticsController : ControllerBase
    {
        private readonly ILogger<SoccerStatisticsController> _logger;

        IMediator _mediator;

        public SoccerStatisticsController(IMediator mediator, ILogger<SoccerStatisticsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet(Name = "GetStandings")]
        public async Task<IActionResult> GetStandings()
        {
            SoccerStandings.Requests.GetStandingRequest standingRequest = new SoccerStandings.Requests.GetStandingRequest
            {
                CompetitionId = 45,
                CompetitionStage = "2600"
            };

            try
            {
                return Ok(await _mediator.Send(standingRequest));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
