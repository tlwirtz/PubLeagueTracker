using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PubLeagueTracker.Models
{
    public class Season
    {
        public int SeasonId { get; set; }
        [Required]
        [Display(Name = "League")]
        public int LeagueId { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public League League { get; set; }
        public IEnumerable<Match> Matches { get; set; }
        public IEnumerable<Team> Teams { get; set; }
    }
}
