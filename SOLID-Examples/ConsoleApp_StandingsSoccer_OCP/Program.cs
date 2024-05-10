using ConsoleApp_StandingsSoccer.Classes.ShowStandingsSoccer;
using ConsoleApp_StandingsSoccer_OCP.Interfaces;

namespace ConsoleApp_StandingsSoccer
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            IStandingsSoccerService liveScoreAPI_StandingsSoccerService = new Classes.StandingsSoccer.LiveScoreAPI.StandingsSoccerService();
            var standings = await liveScoreAPI_StandingsSoccerService.Get(competition_id: 45, stage_id: "2600");

            ShowStandingSoccerService showStandingSoccerService = new();
            showStandingSoccerService.ShowAllStandings(standings);
            showStandingSoccerService.ShowFirstRankTeam(standings);
            showStandingSoccerService.ShowLastRankTeam(standings);
        }
    }
}