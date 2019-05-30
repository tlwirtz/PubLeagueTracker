using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PubLeagueTracker.Models
{
    public class TeamStat
    {
        public int SeasonId { get; set; }
        public int TeamId { get; set; }
        [Display(Name = "Team")]
        public string TeamName { get; set; }
        public int Points { get; set; }
        [Display(Name = "Games Played")]
        public int GamesPlayed { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Draws { get; set; }
    }

    public class SeasonStats
    {
        public Season Season { get; set; }
        public IList<TeamStat> TeamStats { get; set; } = new List<TeamStat>() { };
    }

    public class LeagueStats
    {
        public League League { get; set; }
        public IList<SeasonStats> SeasonStats { get; set; }
    }

    public enum MatchOutcome
    {
        Loss = 0,
        Draw = 1,
        Win = 3
    }
}
