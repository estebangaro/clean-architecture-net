namespace WebApplication_SoccerStandings.Application.SoccerTeamEntity.Commands
{
    public class SoccerTeamUpdateRequest : MediatR.IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
