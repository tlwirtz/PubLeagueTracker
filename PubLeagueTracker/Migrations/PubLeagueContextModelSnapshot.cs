﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PubLeagueTracker.Models.Data;

namespace PubLeagueTracker.Migrations
{
    [DbContext(typeof(PubLeagueContext))]
    partial class PubLeagueContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PubLeagueTracker.Models.League", b =>
                {
                    b.Property<int>("LeagueId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("LeagueId");

                    b.ToTable("League");
                });

            modelBuilder.Entity("PubLeagueTracker.Models.Match", b =>
                {
                    b.Property<int>("MatchId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("MatchDate");

                    b.Property<int>("SeasonId");

                    b.HasKey("MatchId");

                    b.HasIndex("SeasonId");

                    b.ToTable("Match");
                });

            modelBuilder.Entity("PubLeagueTracker.Models.MatchDetail", b =>
                {
                    b.Property<int>("MatchDetailId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsHomeTeam");

                    b.Property<int>("MatchId");

                    b.Property<int?>("Score");

                    b.Property<int>("TeamId");

                    b.HasKey("MatchDetailId");

                    b.HasIndex("MatchId");

                    b.HasIndex("TeamId");

                    b.ToTable("MatchDetail");
                });

            modelBuilder.Entity("PubLeagueTracker.Models.Season", b =>
                {
                    b.Property<int>("SeasonId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LeagueId");

                    b.Property<string>("Name");

                    b.HasKey("SeasonId");

                    b.HasIndex("LeagueId");

                    b.ToTable("Season");
                });

            modelBuilder.Entity("PubLeagueTracker.Models.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("SeasonId");

                    b.HasKey("TeamId");

                    b.HasIndex("SeasonId");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("PubLeagueTracker.Models.Match", b =>
                {
                    b.HasOne("PubLeagueTracker.Models.Season")
                        .WithMany("Matches")
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PubLeagueTracker.Models.MatchDetail", b =>
                {
                    b.HasOne("PubLeagueTracker.Models.Match", "Match")
                        .WithMany("MatchDetail")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PubLeagueTracker.Models.Team", "Team")
                        .WithMany("Matches")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PubLeagueTracker.Models.Season", b =>
                {
                    b.HasOne("PubLeagueTracker.Models.League")
                        .WithMany("Seasons")
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PubLeagueTracker.Models.Team", b =>
                {
                    b.HasOne("PubLeagueTracker.Models.Season")
                        .WithMany("Teams")
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
