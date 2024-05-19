using WebApplication_SoccerStandings.Application.SoccerTeamEntity.Queries;

namespace WebApplication_SoccerStandings.Application.SoccerTeamEntity.Handlers
{
    public class SoccerTeamGetAllHandler : MediatR.IRequestHandler<SoccerTeamGetAllRequest, IEnumerable<SoccerStandings.Classes.SoccerTeamEntity>>
    {
        Interfaces.ISoccerTeamContext _soccerTeamContext;

        public SoccerTeamGetAllHandler(Interfaces.ISoccerTeamContext soccerTeamContext)
        {
            _soccerTeamContext = soccerTeamContext;
        }

        public async Task<IEnumerable<SoccerStandings.Classes.SoccerTeamEntity>> Handle(SoccerTeamGetAllRequest request,
            CancellationToken cancellationToken)
        {
            return await _soccerTeamContext.GetAll();
        }
    }
}