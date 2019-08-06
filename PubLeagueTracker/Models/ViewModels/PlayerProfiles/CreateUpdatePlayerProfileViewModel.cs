using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PubLeagueTracker.Models.ViewModels.PlayerProfiles
{
    public class CreateUpdatePlayerProfileViewModel
    {
        public IEnumerable<League> Leagues { get; set; }
        public IEnumerable<Season> Seasons { get; set; }
        public IEnumerable<Team> Teams { get; set; }
        public PlayerProfile PlayerProfile { get; set; }
    }
}
