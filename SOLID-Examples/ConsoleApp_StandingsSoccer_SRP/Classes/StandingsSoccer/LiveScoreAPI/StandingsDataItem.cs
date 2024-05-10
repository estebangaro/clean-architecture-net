namespace ConsoleApp_StandingsSoccer.Classes.StandingsSoccer.LiveScoreAPI
{
    internal class StandingsDataItem
    {
        public string league_id { get; set; }
        public string season_id { get; set; }
        public string name { get; set; }
        public string rank { get; set; }
        public string points { get; set; }
        public string matches { get; set; }
        public string goal_diff { get; set; }
        public string goals_scored { get; set; }
        public string goals_conceded { get; set; }
        public string lost { get; set; }
        public string drawn { get; set; }
        public string won { get; set; }
        public string team_id { get; set; }
        public string competition_id { get; set; }
        public string group_id { get; set; }
        public string group_name { get; set; }
        public string stage_name { get; set; }
        public string stage_id { get; set; }
    }
}
