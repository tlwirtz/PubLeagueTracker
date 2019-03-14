using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PubLeagueTracker.Models;
using PubLeagueTracker.Models.Data;
using PubLeagueTracker.Models.ViewModels.Teams;
using System.Linq;
using System.Threading.Tasks;

namespace PubLeagueTracker.Controllers
{
    public class TeamsController : Controller
    {
        private readonly PubLeagueContext _context;

        public TeamsController(PubLeagueContext context)
        {
            _context = context;
        }

        // GET: Teams
        public async Task<IActionResult> Index()
        {
            return View(await _context.Teams.Include(t => t.Season).ThenInclude(s => s.League).ToListAsync());
        }

        // GET: Teams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams.Include(t => t.Season).ThenInclude(s => s.League).FirstOrDefaultAsync(m => m.TeamId == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // GET: Teams/Create
        public async Task<IActionResult> Create()
        {
            var leagues = await _context.Leagues.ToListAsync();
            var seasons = await _context.Seasons.Where(m => m.LeagueId == leagues.First().LeagueId).ToListAsync();
            var view = new CreateUpdateTeamViewModel()
            {
                Leagues = leagues,
                Seasons = seasons
            };

            return View(view);
        }

        // POST: Teams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeamId,SeasonId,Name")] Team team)
        {
            if (ModelState.IsValid)
            {
                _context.Add(team);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(team);
        }

        // GET: Teams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams.Include(t => t.Season).ThenInclude(s => s.League).FirstOrDefaultAsync(t => t.TeamId == id);
            var leagues = await _context.Leagues.ToListAsync();
            var seasons = await _context.Seasons.Where(s => s.LeagueId == team.Season.LeagueId).ToListAsync();

            if (team == null)
            {
                return NotFound();
            }

            var view = new CreateUpdateTeamViewModel()
            {
                Team = team,
                Leagues = leagues,
                Seasons = seasons
            };

            return View(view);
        }

        // POST: Teams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TeamId,SeasonId,Name")] Team team)
        {
            if (id != team.TeamId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(team);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamExists(team.TeamId))
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
            return View(team);
        }

        // GET: Teams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams
                .FirstOrDefaultAsync(m => m.TeamId == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> GetSeasonsByLeagueId(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seasons = await _context.Seasons.Where(m => m.LeagueId == id).ToListAsync();

            if (seasons.Count == 0)
            {
                return NotFound();
            }

            return Json(new SelectList(seasons, "SeasonId", "Name"));
        }

        [HttpGet]
        public async Task<IActionResult> GetTeamsBySeasonId(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teams = await _context.Teams.Where(t => t.SeasonId == id).ToListAsync();
            if  (teams.Count == 0)
            {
                return NotFound();
            }

            return Json(new SelectList(teams, "TeamId", "Name"));
        }

        private bool TeamExists(int id)
        {
            return _context.Teams.Any(e => e.TeamId == id);
        }
    }
}
