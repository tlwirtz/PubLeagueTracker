using System;
using System.Collections.Generic;

namespace PubLeagueTracker.Models
{
    public class Season
    {
        public int SeasonId { get; set; }
        public int LeagueId { get; set; }
        public string Name { get; set; }
        public IEnumerable<Match> Matches { get; set; }
        public IEnumerable<Team> Teams { get; set; }
    }
}
