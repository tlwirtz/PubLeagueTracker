using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PubLeagueTracker.Models
{
    public class PlayerProfile
    {
        public int PlayerProfileId { get; set; }
        public int TeamId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
