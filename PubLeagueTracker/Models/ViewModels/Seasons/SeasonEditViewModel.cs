using System.Collections.Generic;

namespace PubLeagueTracker.Models.ViewModels
{
    public class SeasonEditViewModel
    {
        public Season Season { get; set; }
        public IEnumerable<League> Leagues { get; set; }
    }
}
