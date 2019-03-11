using System;
using System.Collections.Generic;

namespace PubLeagueTracker.Models
{
    public class League
    {
        public int LeagueId { get; set; }
        public string Name { get; set; }
        public IEnumerable<Season> Seasons { get; set; }
    }
}
