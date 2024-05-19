using WebApplication_SoccerStandings.Application.SoccerTeamEntity.Commands;
using WebApplication_SoccerStandings.Interfaces;

namespace WebApplication_SoccerStandings.Application.SoccerTeamEntity.Handlers
{
    public class SoccerTeamAddHandler : MediatR.IRequestHandler<SoccerTeamAddRequest, int>
    {
        ISoccerTeamContext _context;

        public SoccerTeamAddHandler(ISoccerTeamContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(SoccerTeamAddRequest request, CancellationToken cancellationToken)
        {
            return await _context.Add(new SoccerStandings.Classes.SoccerTeamEntity
            {
                Name = request.Name,
                CountryId = request.CountryId,
                Stadium = request.Stadium
            });
        }
    }
}
