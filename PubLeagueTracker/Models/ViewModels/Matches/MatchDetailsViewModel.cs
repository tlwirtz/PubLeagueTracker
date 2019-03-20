using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PubLeagueTracker.Models.ViewModels.Matches
{
    public class MatchDetailsViewModel
    {
        public int MatchId { get; set; }
        public DateTime MatchDate { get; set; }
        public string Location { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public int? AwayScore { get; set; }
        public int? HomeScore { get; set; }
    }
}
