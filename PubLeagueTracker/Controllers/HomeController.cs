using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PubLeagueTracker.Models;
using PubLeagueTracker.Models.Data;

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
            var view = new HomeViewModel { Leagues = _context.Leagues.Include(league => league.Seasons).ToList() };
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
    }
}
