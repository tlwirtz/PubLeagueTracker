using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PubLeagueTracker.Models
{
    public class League
    {
        public int LeagueId { get; set; }
        [Required]
        public string Name { get; set; }
        public IEnumerable<Season> Seasons { get; set; }
    }
}
