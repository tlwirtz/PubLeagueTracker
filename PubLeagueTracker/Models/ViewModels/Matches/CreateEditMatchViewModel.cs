using System.Collections.Generic;

namespace PubLeagueTracker.Models.ViewModels.Matches
{
    public class CreateEditMatchViewModel
    {
        public IEnumerable<Season> Seasons { get; set; }
        public IEnumerable<League> Leagues { get; set; }
        public Match Match { get; set; }
    }
}
