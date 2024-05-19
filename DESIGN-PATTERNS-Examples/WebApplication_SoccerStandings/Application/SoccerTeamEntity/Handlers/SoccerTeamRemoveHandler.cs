using WebApplication_SoccerStandings.Application.SoccerTeamEntity.Commands;
using WebApplication_SoccerStandings.Interfaces;

namespace WebApplication_SoccerStandings.Application.SoccerTeamEntity.Handlers
{
    public class SoccerTeamRemoveHandler : MediatR.IRequestHandler<SoccerTeamRemoveRequest, bool>
    {
        ISoccerTeamContext _context;

        public SoccerTeamRemoveHandler(ISoccerTeamContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(SoccerTeamRemoveRequest request, CancellationToken cancellationToken)
        {
            return await _context.Remove(request.Id);
        }
    }
}
