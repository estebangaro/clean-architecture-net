using WebApplication_SoccerStandings.Application.SoccerTeamEntity.Queries;

namespace WebApplication_SoccerStandings.Application.SoccerTeamEntity.Handlers
{
    public class SoccerTeamGetByIdHandler : MediatR.IRequestHandler<SoccerTeamGetByIdRquest, SoccerStandings.Classes.SoccerTeamEntity>
    {
        Interfaces.ISoccerTeamContext _soccerTeamContext;

        public SoccerTeamGetByIdHandler(Interfaces.ISoccerTeamContext soccerTeamContext)
        {
            _soccerTeamContext = soccerTeamContext;
        }

        public async Task<SoccerStandings.Classes.SoccerTeamEntity> Handle(SoccerTeamGetByIdRquest request, CancellationToken cancellationToken)
        {
            return await _soccerTeamContext.GetById(request.Id);
        }
    }
}