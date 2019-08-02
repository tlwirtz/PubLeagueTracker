using System.Collections.Generic;
using System.Linq;

namespace PubLeagueTracker.Models.ViewModels.Matches
{
    public class MatchIndexViewModel
    {
        public IEnumerable<IGrouping<Season, Match>> Matches { get; set; }
        public IEnumerable<Team> Teams { get; set; }
        public int? TeamId { get; set; }
    }
}
