using MediatR;
using SoccerStandings.Classes;
using SoccerStandings.Requests;

namespace SoccerStandingsv2.Behaviours
{
    public class StandingRequestCompetitionIdPipelineBehaviour : IPipelineBehavior<GetStandingRequest, IEnumerable<StandingTeamInformation>>
    {
        public Task<IEnumerable<StandingTeamInformation>> Handle(GetStandingRequest request,
            RequestHandlerDelegate<IEnumerable<StandingTeamInformation>> next, CancellationToken cancellationToken)
        {
            System.Diagnostics.Debug.WriteLine($"Iniciando ejecución de \"StandingRequestCompetitionIdPipelineBehaviour\"");

            if (request.CompetitionId != 45)
            {
                throw new ArgumentException($"El id de competición \"{request.CompetitionId}\" no es válido!");
            }

            return next();
        }
    }
}
