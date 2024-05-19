namespace WebApplication_SoccerStandings.Application.SoccerTeamEntity.Queries
{
    public class SoccerTeamGetByIdRquest : MediatR.IRequest<SoccerStandings.Classes.SoccerTeamEntity>
    {
        public int Id { get; set; }
    }
}