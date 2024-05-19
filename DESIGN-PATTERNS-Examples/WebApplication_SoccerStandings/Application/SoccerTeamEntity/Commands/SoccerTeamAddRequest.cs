namespace WebApplication_SoccerStandings.Application.SoccerTeamEntity.Commands
{
    public class SoccerTeamAddRequest : MediatR.IRequest<int>
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public string Stadium { get; set; }
    }
}
