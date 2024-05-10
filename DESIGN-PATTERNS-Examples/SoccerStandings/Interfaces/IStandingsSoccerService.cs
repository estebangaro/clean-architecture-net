using SoccerStandings.Classes;

namespace SoccerStandings.Interfaces
{
    public interface IStandingsSoccerService
    {
        Task<IEnumerable<StandingTeamInformation>> Get(int competition_id, string stage_id);
    }
}