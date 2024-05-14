using SoccerStandings.Classes;

namespace SoccerStandings.Requests
{
    public class GetStandingRequest : MediatR.IRequest<IEnumerable<StandingTeamInformation>>
    {
        public int CompetitionId { get; set; }
        public string CompetitionStage { get; set; }
    }
}
