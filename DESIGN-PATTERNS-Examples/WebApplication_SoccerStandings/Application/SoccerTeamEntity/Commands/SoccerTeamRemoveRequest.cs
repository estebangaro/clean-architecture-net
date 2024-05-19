namespace WebApplication_SoccerStandings.Application.SoccerTeamEntity.Commands
{
    public class SoccerTeamRemoveRequest : MediatR.IRequest<bool>
    {
        public int Id { get; set; }
    }
}
