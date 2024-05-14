namespace WebApplication_SoccerStandings.DbContext;

public partial class SoccerTeam
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Stadium { get; set; }

    public int CountryId { get; set; }
}
