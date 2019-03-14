using System;
using System.Collections.Generic;


namespace PubLeagueTracker.Models
{
    public class Match
    {
        public int MatchId { get; set; }
        public int SeasonId { get; set; }
        public string Location { get; set; }
        public DateTime MatchDate { get; set; }

        public Season Season { get; set; }
        public List<MatchDetail> MatchDetail { get; set; }
    }

    /*
     * TODO -- issue building this, might need to change PubLeagueContext
     */

    public class MatchDetail
    {
        public int MatchDetailId { get; set; }
        public int MatchId { get; set; }
        public int TeamId { get; set; }
        public bool IsHomeTeam { get; set; }
        public int? Score { get; set; }


        public Team Team { get; set; }
        public Match Match { get; set; }
    }

}
