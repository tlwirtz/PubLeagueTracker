using System;
using System.Collections.Generic;

namespace PubLeagueTracker.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public int SeasonId { get; set; }
        public string Name { get; set; }

        public IEnumerable<MatchDetail> Matches { get; set; }
    }
}
