namespace SoccerStandings.Classes
{
    public class SoccerTeamEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Foundation { get; set; }
        public byte LocalTitles { get; set; }
        public int CountryId { get; set; }
        public string Stadium { get; set; }

    }
}
