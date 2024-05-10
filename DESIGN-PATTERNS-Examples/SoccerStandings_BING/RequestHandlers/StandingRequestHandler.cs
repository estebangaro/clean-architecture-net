using SoccerStandings.Classes;
using SoccerStandings.Interfaces;
using SoccerStandings.Requests;
using SoccerStandings_BING.DataSource;

namespace SoccerStandings_BING.RequestHandlers
{
    public class StandingRequestHandler : Mediator.RequestHandlers.IRequestHandler<GetStandingRequest, IEnumerable<StandingTeamInformation>>
    {
        IStandingsSoccerService _standingsSoccerService;

        public StandingRequestHandler()
        {
            _standingsSoccerService = new StandingsSoccerService();
        }

        public Task<IEnumerable<StandingTeamInformation>> Handle(GetStandingRequest requestType, CancellationToken cancellationToken)
        {
            return _standingsSoccerService.Get(requestType.CompetitionId, requestType.CompetitionStage);
        }
    }
}