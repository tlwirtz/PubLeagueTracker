using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PubLeagueTracker.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        [Required]
        [Display(Name = "Season")]
        public int SeasonId { get; set; }
        [Required]
        public string Name { get; set; }

        public Season Season { get; set; }
        public IEnumerable<MatchDetail> Matches { get; set; }
    }
}
