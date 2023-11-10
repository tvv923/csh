using CinemaTheater.Data;
using CinemaTheater.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTheater.Controllers
{
    public class ShowController : Controller
    {
        private readonly CinemaTheaterDbContext _context;

        public ShowController(CinemaTheaterDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int id)
        {
            IEnumerable<Show> shows = _context.Shows
                .Where(s => _context.MovieShows.Any(ms => ms.MovieId == id && ms.ShowId == s.Id))
                .ToList();

            return View(shows);
        }    
    }
}
