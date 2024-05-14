using MediatR;
using SoccerStandings.Classes;
using SoccerStandings.Requests;

namespace SoccerStandingsv2.Behaviours
{
    public class StandingRequestPipelineBehaviour : IPipelineBehavior<GetStandingRequest, IEnumerable<StandingTeamInformation>>
    {
        public Task<IEnumerable<StandingTeamInformation>> Handle(GetStandingRequest request,
            RequestHandlerDelegate<IEnumerable<StandingTeamInformation>> next, CancellationToken cancellationToken)
        {
            System.Diagnostics.Debug.WriteLine($"Iniciando ejecución de \"StandingRequestPipelineBehaviour\"");

            if (!(request.CompetitionId > 0 && !string.IsNullOrEmpty(request.CompetitionStage)))
            {
                throw new ArgumentException("Favor de proporcionar los valores de Id de Competencia y Fase de Competencia!");
            }

            var nextResult = next();

            System.Diagnostics.Debug.WriteLine($"Finalizando ejecución de \"StandingRequestPipelineBehaviour\"");

            return nextResult;
        }
    }
}
