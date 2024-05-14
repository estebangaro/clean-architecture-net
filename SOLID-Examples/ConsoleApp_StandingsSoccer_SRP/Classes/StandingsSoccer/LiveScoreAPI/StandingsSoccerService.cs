﻿using System.Net.Http.Json;

namespace ConsoleApp_StandingsSoccer.Classes.StandingsSoccer.LiveScoreAPI
{
    internal class StandingsSoccerService
    {
        private const string _baseAddress_uriString = "https://livescore-api.com";
        private const string _key = "uPhyO7IEa6mZhhmB";
        private const string _secret = "EwZpYeAqi6i8acdE1vdQCVvN1RMj99UN";

        // HttpClient lifecycle management best practices:
        // https://learn.microsoft.com/dotnet/fundamentals/networking/http/httpclient-guidelines#recommended-use
        private static HttpClient _sharedClient;

        static StandingsSoccerService()
        {
            _sharedClient = new()
            {
                BaseAddress = new Uri(_baseAddress_uriString)
            };
        }

        public async Task<IEnumerable<StandingTeamInformation>> Get(int competition_id, string stage_id)
        {
            var response = await _sharedClient.GetFromJsonAsync<StandingsResponse>($"api-client/leagues/table.json?competition_id={competition_id}&key={_key}&secret={_secret}");

            if (response == null || !response.success || response.data == null || response.data.table == null || !response.data.table.Any())
            {
                throw new Exception("Datos no disponibles!!");
            }

            return response.data.table.Where(item => item.stage_id == stage_id).Select(item => new StandingTeamInformation
            {
                Points = short.Parse(item.points),
                Position = byte.Parse(item.rank),
                Team = new SoccerTeamEntity
                {
                    Name = item.name
                }
            });
        }
    }
}