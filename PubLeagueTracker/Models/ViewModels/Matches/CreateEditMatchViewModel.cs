using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PubLeagueTracker.Models.ViewModels.Matches
{
    public class CreateEditMatchViewModel
    {
        public IEnumerable<Season> Seasons { get; set; }
        public IEnumerable<League> Leagues { get; set; }
        public Match Match { get; set; }
    }
}
