using System;
using Microsoft.EntityFrameworkCore;
using PubLeagueTracker.Models;

namespace PubLeagueTracker.Models.Data
{
    public class PubLeagueContext : DbContext
    {
        public PubLeagueContext(DbContextOptions<PubLeagueContext> options) : base(options)
        {

        }

        public DbSet<League> Leagues { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<MatchDetail> MatchDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<League>().ToTable("League");
            modelBuilder.Entity<Season>().ToTable("Season");
            modelBuilder.Entity<Team>().ToTable("Team");
            modelBuilder.Entity<Match>().ToTable("Match");
            modelBuilder.Entity<MatchDetail>().ToTable("MatchDetail");
        }

        public DbSet<PlayerProfile> PlayerProfile { get; set; }
    }
}
