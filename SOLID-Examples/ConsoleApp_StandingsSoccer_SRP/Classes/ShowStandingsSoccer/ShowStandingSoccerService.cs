namespace ConsoleApp_StandingsSoccer.Classes.ShowStandingsSoccer
{
    internal class ShowStandingSoccerService
    {
        public void ShowFirstRankTeam(IEnumerable<StandingTeamInformation> standingTeamInformation)
        {
            Console.WriteLine("El equipo posición #1 de la Liga MX: " + standingTeamInformation.OrderBy(item => item.Position).First().Team.Name);
        }

        public void ShowLastRankTeam(IEnumerable<StandingTeamInformation> standingTeamInformation)
        {
            Console.WriteLine($"El equipo posición #{standingTeamInformation.Count()} de la Liga MX: " + standingTeamInformation.OrderBy(item => item.Position).Last().Team.Name);
        }

        public void ShowAllStandings(IEnumerable<StandingTeamInformation> standingTeamInformation)
        {
            short position = 1;
            foreach (var sta in standingTeamInformation)
            {
                Console.WriteLine($"{position++}) {sta.Team.Name.PadRight(25, ' ')}\t\t{sta.Points}");
            }
        }
    }
}
