using SoccerStandings.Classes;
using SoccerStandings.Interfaces;
using SoccerStandings.Requests;
using SoccerStandings_API.DataSource.LiveScoreAPI;

namespace SoccerStandings_API.RequestHandlers
{
    public class StandingRequestHandler : MediatR.IRequestHandler<GetStandingRequest, IEnumerable<StandingTeamInformation>>
    {
        IStandingsSoccerService _standingsSoccerService;

        public StandingRequestHandler()
        {
            _standingsSoccerService = new StandingsSoccerService();
        }

        public Task<IEnumerable<StandingTeamInformation>> Handle(GetStandingRequest requestType, CancellationToken cancellationToken)
        {
            System.Diagnostics.Debug.WriteLine($"Iniciando ejecución de \"StandingRequestHandler\"");

            var result = _standingsSoccerService.Get(requestType.CompetitionId, requestType.CompetitionStage);

            System.Diagnostics.Debug.WriteLine($"Finalizando ejecución de \"StandingRequestHandler\"");

            return result;
        }
    }
}