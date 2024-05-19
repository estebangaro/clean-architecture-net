using Microsoft.EntityFrameworkCore;
using SoccerStandings.Classes;
using WebApplication_SoccerStandings.DbContext;
using WebApplication_SoccerStandings.Interfaces;

namespace WebApplication_SoccerStandings.Models
{
    public class SoccerTeamContext : ISoccerTeamContext
    {
        TestsContext _testContext;

        public SoccerTeamContext(TestsContext testsContext)
        {
            _testContext = testsContext;
        }

        public async Task<int> Add(SoccerTeamEntity soccerTeam)
        {
            var entityEntry = await _testContext.SoccerTeams.AddAsync(new SoccerTeam
            {
                CountryId = soccerTeam.CountryId,
                Name = soccerTeam.Name,
                Stadium = soccerTeam.Stadium
            });

            var result = await _testContext.SaveChangesAsync();

            if (result > 0)
            {
                return entityEntry.Entity.Id;
            }
            throw new Exception("Falló el registro del equipo!");
        }

        public async Task<IEnumerable<SoccerTeamEntity>> GetAll()
        {
            return await _testContext.SoccerTeams.Select(st => new SoccerTeamEntity
            {
                Foundation = DateTime.Now,
                Name = st.Name,
                Id = st.Id,
                LocalTitles = 0
            }).ToListAsync();
        }

        public async Task<SoccerTeamEntity> GetById(int id)
        {
            var st = await _testContext.SoccerTeams.FindAsync(id);

            if (st != null)
            {
                return new SoccerTeamEntity
                {
                    Foundation = DateTime.Now,
                    Name = st.Name,
                    Id = st.Id,
                    LocalTitles = 0
                };
            }
            throw new Exception("El equipo espicificado, no existe!");
        }

        public async Task<bool> Remove(int id)
        {
            var st = await _testContext.SoccerTeams.FindAsync(id);

            if (st != null)
            {
                _testContext.SoccerTeams.Remove(st);
                var result = await _testContext.SaveChangesAsync();

                if (result == 0)
                {
                    throw new Exception("Ha fallado la eliminación del equipo!");
                }
                return true;
            }
            throw new Exception("El equipo espicificado, no existe!");
        }

        public async Task<bool> Update(SoccerTeamEntity soccerTeam)
        {
            var st = await _testContext.SoccerTeams.FindAsync(soccerTeam.Id);

            if (st != null)
            {
                st.Name = soccerTeam.Name;
                var result = await _testContext.SaveChangesAsync();

                if (result == 0)
                {
                    throw new Exception("Ha fallado la actualización del equipo!");
                }
                return true;
            }
            throw new Exception("El equipo espicificado, no existe!");
        }
    }
}
