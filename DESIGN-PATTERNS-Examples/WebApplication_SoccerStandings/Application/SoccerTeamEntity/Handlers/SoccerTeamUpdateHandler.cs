using WebApplication_SoccerStandings.Application.SoccerTeamEntity.Commands;
using WebApplication_SoccerStandings.Interfaces;

namespace WebApplication_SoccerStandings.Application.SoccerTeamEntity.Handlers
{
    public class SoccerTeamUpdateHandler : MediatR.IRequestHandler<SoccerTeamUpdateRequest, bool>
    {
        ISoccerTeamContext _context;

        public SoccerTeamUpdateHandler(ISoccerTeamContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(SoccerTeamUpdateRequest request, CancellationToken cancellationToken)
        {
            return await _context.Update(new SoccerStandings.Classes.SoccerTeamEntity
            {
                Id = request.Id,
                Name = request.Name
            });
        }
    }
}
