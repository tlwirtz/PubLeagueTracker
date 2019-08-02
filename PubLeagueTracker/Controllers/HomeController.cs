using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PubLeagueTracker.Models;
using PubLeagueTracker.Models.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PubLeagueTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly PubLeagueContext _context;

        public HomeController(PubLeagueContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var results = _context.Leagues
                    .Include(l => l.Seasons)
                    .ThenInclude(s => s.Matches)
                    .ThenInclude(m => m.MatchDetail)
                    .ThenInclude(md => md.Team)
                    .Include(l => l.Seasons)
                    .ThenInclude(s => s.Teams)
                    .ToList();


            var teams = _context.Teams.Include(t => t.Season).ToList();
            var matches = _context.Matches.Include(m => m.MatchDetail);

            //Calculate all the match outcomes for each teaim.
            var teamData = teams.Where(t => t.Season.IsActive).Select(t =>
            {
                var matchOutcomes = CalcMatchOutcomes(t.TeamId, matches);
                return new TeamStat()
                {
                    SeasonId = t.SeasonId,
                    TeamId = t.TeamId,
                    TeamName = t.Name,
                    Wins = matchOutcomes.Where(mo => mo == MatchOutcome.Win).Count(),
                    Losses = matchOutcomes.Where(mo => mo == MatchOutcome.Loss).Count(),
                    Draws = matchOutcomes.Where(mo => mo == MatchOutcome.Draw).Count(),
                    GamesPlayed = matchOutcomes.Count(),
                    Points = matchOutcomes.Select(mo => (int)mo).Sum()
                };
            });

            //Group match outcome with season and league
            var view = results.Select(league =>
            {
                return new LeagueStats()
                {
                    League = league,
                    SeasonStats = league.Seasons
                        .Where(season => season.IsActive)
                        .Select(season =>
                            new SeasonStats()
                            {
                                Season = season,
                                TeamStats = teamData.Where(td => td.SeasonId == season.SeasonId).ToList()
                            }
                        ).ToList()
                };
            });

            return View(view);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //TODO -- this should be refactored out into a service so it can be used in other areas
        private IEnumerable<MatchOutcome> CalcMatchOutcomes(int teamId, IEnumerable<Match> matches)
        {
            return matches
                    .Where(match => match.MatchDate < DateTime.Now)
                    .Where(match => match.MatchDetail.Where(md => md.TeamId == teamId).ToList().Any())
                    .Select(match =>
                    {
                        var targetTeam = match.MatchDetail.Where(md => md.TeamId == teamId).First();
                        var awayTeam = match.MatchDetail.Where(md => md.TeamId != teamId).First();

                        if (awayTeam.Score == targetTeam.Score)
                        {
                            return MatchOutcome.Draw;
                        }

                        if (targetTeam.Score > awayTeam.Score)
                        {
                            return MatchOutcome.Win;
                        }

                        return MatchOutcome.Loss;
                    });
        }
    }
}
