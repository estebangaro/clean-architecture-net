using ConsoleApp_StandingsSoccer.Classes;

namespace ConsoleApp_StandingsSoccer_OCP.Interfaces
{
    public interface IStandingsSoccerService
    {
        Task<IEnumerable<StandingTeamInformation>> Get(int competition_id, string stage_id);
    }
}