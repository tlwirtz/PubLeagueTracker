using System.Collections.Generic;

namespace PubLeagueTracker.Models.ViewModels
{
    public class CreateEditSeasonViewModel
    {
        public Season Season { get; set; }
        public IEnumerable<League> Leagues { get; set; }
    }
}
