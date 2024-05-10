using ConsoleApp_StandingsSoccer_OCP.Interfaces;
using System.Xml;

namespace ConsoleApp_StandingsSoccer.Classes.StandingsSoccer.TXT
{
    public class StandingsSoccerService : IStandingsSoccerService
    {
        const string data_source_path = @"Classes\StandingsSoccer\TXT\data_source.xml";

        public Task<IEnumerable<StandingTeamInformation>> Get(int competition_id, string stage_id)
        {
            var dataPath = Path.Combine(AppContext.BaseDirectory, data_source_path);
            if (File.Exists(dataPath))
            {
                XmlDocument xmlDocument = new();
                xmlDocument.Load(dataPath);
                var competition_id_s = competition_id.ToString();

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                IEnumerable<StandingTeamInformation> teamsRank = xmlDocument.SelectNodes("xml/table")?.Cast<XmlNode>()
                    .Where(node => node.SelectSingleNode("competition_id")?.InnerText == competition_id_s
                        && node.SelectSingleNode("stage_id")?.InnerText == stage_id)
                    .Select(node => new StandingTeamInformation
                    {
                        Points = short.Parse(node.SelectSingleNode("points")?.InnerText ?? "0"),
                        Position = byte.Parse(node.SelectSingleNode("rank")?.InnerText ?? "0"),
                        Team = new SoccerTeamEntity
                        {
                            Name = node.SelectSingleNode("name")?.InnerText ?? "n/d"
                        }
                    });
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
                return Task.FromResult(teamsRank);
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.
            }
            throw new NotSupportedException("El archivo no se encuentra disponible!");
        }
    }
}