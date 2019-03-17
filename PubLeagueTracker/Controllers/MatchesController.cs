using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PubLeagueTracker.Models;
using PubLeagueTracker.Models.Data;
using PubLeagueTracker.Models.ViewModels.Matches;

namespace PubLeagueTracker.Controllers
{
    public class MatchesController : Controller
    {
        private readonly PubLeagueContext _context;

        public MatchesController(PubLeagueContext context)
        {
            _context = context;
        }

        // GET: Matches
        public async Task<IActionResult> Index()
        {
            return View(await _context.Matches
                .Include(m => m.Season)
                .ThenInclude(s => s.League)
                .Include(m => m.MatchDetail)
                .ThenInclude(md => md.Team)
                .ToListAsync());
        }

        // GET: Matches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _context.Matches
                .Include(m => m.Season)
                .ThenInclude(s => s.League)
                .Include(m => m.MatchDetail)
                .ThenInclude(md => md.Team)
                .FirstOrDefaultAsync(m => m.MatchId == id);

            if (match == null)
            {
                return NotFound();
            }

            return View(match);
        }

        // GET: Matches/Create
        public async Task<IActionResult> Create()
        {
            var leagues = await _context.Leagues.ToListAsync();
            var seasons = await _context.Seasons
                .Include(s => s.Teams)
                .Where(m => m.LeagueId == leagues.First().LeagueId)
                .ToListAsync();
            

            var view = new CreateEditMatchViewModel()
            {
                Seasons = seasons,
                Leagues = leagues
            };

            return View(view);
        }

        // POST: Matches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MatchId,SeasonId,MatchDate,Location,MatchDetail")] Match match)
        {
            if (ModelState.IsValid)
            {
                _context.Add(match);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(match);
        }

        // GET: Matches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = _context.Matches
                .Include(m => m.Season)
                    .ThenInclude(s =>  s.Teams)
                .Include(m => m.MatchDetail)
                    .ThenInclude(md => md.Team)
                .Where(m => m.MatchId == id)
                .First();

            if (match == null)
            {
                return NotFound();
            }

            return View(match);
        }

        // POST: Matches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MatchId,SeasonId,MatchDate,Location,MatchDetail,Season")] Match match)
        {
            if (id != match.MatchId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(match);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatchExists(match.MatchId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            //we don't pass the season information along, so go get it again.
            if (match.Season == null)
            {
                match.Season = _context.Matches
                    .Include(m => m.Season)
                        .ThenInclude(s => s.Teams)
                    .Where(m => m.MatchId == id)
                    .First().Season;
            }

            return View(match);
        }

        // GET: Matches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _context.Matches
                .FirstOrDefaultAsync(m => m.MatchId == id);
            if (match == null)
            {
                return NotFound();
            }

            return View(match);
        }

        // POST: Matches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var match = await _context.Matches.FindAsync(id);
            _context.Matches.Remove(match);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatchExists(int id)
        {
            return _context.Matches.Any(e => e.MatchId == id);
        }
    }
}
