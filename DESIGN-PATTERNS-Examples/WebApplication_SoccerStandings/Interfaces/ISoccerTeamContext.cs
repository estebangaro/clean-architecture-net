using SoccerStandings.Classes;

namespace WebApplication_SoccerStandings.Interfaces
{
    public interface ISoccerTeamContext
    {
        Task<int> Add(SoccerTeamEntity product);
        Task<bool> Remove(int id);
        Task<bool> Update(SoccerTeamEntity product);
        Task<IEnumerable<SoccerTeamEntity>> GetAll();
        Task<SoccerTeamEntity> GetById(int id);
    }
}
