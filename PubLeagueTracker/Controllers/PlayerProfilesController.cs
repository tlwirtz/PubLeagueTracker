using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PubLeagueTracker.Models;
using PubLeagueTracker.Models.Data;
using PubLeagueTracker.Models.ViewModels.PlayerProfiles;

namespace PubLeagueTracker.Controllers
{
    public class PlayerProfilesController : Controller
    {
        private readonly PubLeagueContext _context;

        public PlayerProfilesController(PubLeagueContext context)
        {
            _context = context;
        }

        // GET: PlayerProfiles
        public async Task<IActionResult> Index()
        {
            return View(await _context.PlayerProfile.ToListAsync());
        }

        // GET: PlayerProfiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerProfile = await _context.PlayerProfile
                .FirstOrDefaultAsync(m => m.PlayerProfileId == id);
            if (playerProfile == null)
            {
                return NotFound();
            }

            return View(playerProfile);
        }

        // GET: PlayerProfiles/Create
        public async Task<IActionResult> Create()
        {
            var leagues = await _context.Leagues.ToListAsync();
            var seasons = await _context.Seasons.Where(m => m.LeagueId == leagues.First().LeagueId).ToListAsync();
            var teams = await _context.Teams.Where(t => t.SeasonId == seasons.First().SeasonId).ToListAsync();

            var view = new CreateUpdatePlayerProfileViewModel()
            {
                Leagues = leagues,
                Seasons = seasons,
                Teams = teams
            };

            return View(view);
        }

        // POST: PlayerProfiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlayerProfileId,TeamId,FirstName,LastName")] PlayerProfile playerProfile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(playerProfile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(playerProfile);
        }

        // GET: PlayerProfiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerProfile = await _context.PlayerProfile.FindAsync(id);
            if (playerProfile == null)
            {
                return NotFound();
            }
            return View(playerProfile);
        }

        // POST: PlayerProfiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlayerProfileId,TeamId,FirstName,LastName")] PlayerProfile playerProfile)
        {
            if (id != playerProfile.PlayerProfileId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playerProfile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerProfileExists(playerProfile.PlayerProfileId))
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
            return View(playerProfile);
        }

        // GET: PlayerProfiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerProfile = await _context.PlayerProfile
                .FirstOrDefaultAsync(m => m.PlayerProfileId == id);
            if (playerProfile == null)
            {
                return NotFound();
            }

            return View(playerProfile);
        }

        // POST: PlayerProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var playerProfile = await _context.PlayerProfile.FindAsync(id);
            _context.PlayerProfile.Remove(playerProfile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlayerProfileExists(int id)
        {
            return _context.PlayerProfile.Any(e => e.PlayerProfileId == id);
        }
    }
}
