using HtmlAgilityPack;
using SoccerStandings.Classes;
using SoccerStandings.Interfaces;

namespace SoccerStandings_BING.DataSource
{
    public class StandingsSoccerService : IStandingsSoccerService
    {
        const string urlBing = @"https://www.bing.com/sportsdetails?q=tabla%20de%20posiciones%20liga%20mx&sport=Soccer&scenario=League&TimezoneId=Central%20Standard%20Time%20(Mexico)&league=Soccer_MexicoPrimeraDivisionClausura&intent=Standings&seasonyear=2024&segment=sports&isl2=true&form=QBRE&";

        public async Task<IEnumerable<StandingTeamInformation>> Get(int competition_id, string stage_id)
        {
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = await web.LoadFromWebAsync(urlBing);
            var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@data-tag='BingSports.Standings']//table/tr[@class='bsp_row_item']");

            return nodes.Select(node => new StandingTeamInformation
            {
                Points = short.Parse(node.SelectSingleNode("td[3]").InnerText),
                Position = byte.Parse(node.SelectSingleNode("td[1]/span").InnerText),
                Team = new SoccerTeamEntity
                {
                    Name = node.SelectSingleNode("td[1]/a/span").InnerText
                }
            });
        }
    }
}