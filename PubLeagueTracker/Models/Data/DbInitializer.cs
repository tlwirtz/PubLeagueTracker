using System;
using System.Linq;

namespace PubLeagueTracker.Models.Data
{
    public class DbInitializer
    {
        public static void Initialize(PubLeagueContext context)
        {
            context.Database.EnsureCreated();

            if (context.Teams.Any())
            {
                return; //already seeded the db
            }

            //add a league
            context.Leagues.Add(new League { Name = "Premier League" });
            context.SaveChanges();

            //add a season
            context.Seasons.Add(new Season { Name = "Spring 2019", LeagueId = 2});
            context.SaveChanges();
        }
    }
}
