using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PubLeagueTracker.Models.ViewModels.Teams
{
    public class CreateUpdateTeamViewModel
    {
        public IEnumerable<Season> Seasons { get; set; }
        public IEnumerable<League> Leagues { get; set; }
        public Team Team { get; set; }
    }
}
