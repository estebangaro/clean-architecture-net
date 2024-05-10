using SoccerStandings.Classes;
using SoccerStandings.Interfaces;
using SoccerStandings.Requests;
using SoccerStandings_API.DataSource.LiveScoreAPI;

namespace SoccerStandings_API.RequestHandlers
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