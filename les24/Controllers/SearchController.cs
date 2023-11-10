using CinemaTheater.Data;
using CinemaTheater.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTheater.Controllers
{
    public class SearchController : Controller
    {
        private readonly CinemaTheaterDbContext _context;

        public SearchController(CinemaTheaterDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string myName, string director, string style, string description, string showTime)
        {
            var query = _context.Movies
                .Join(_context.MovieShows, movie => movie.Id, movieShow => movieShow.MovieId, (movie, movieShow) => new { movie, movieShow })
                .Join(_context.Shows, x => x.movieShow.ShowId, show => show.Id, (x, show) => new { x.movie, show })
                .Where(x =>
                     (string.IsNullOrEmpty(myName) || x.movie.Name.ToLower().Contains(myName.ToLower())) &&
                     (string.IsNullOrEmpty(director) || x.movie.Director.ToLower().Contains(director.ToLower())) &&
                     (string.IsNullOrEmpty(style) || x.movie.Style.ToLower().Contains(style.ToLower())) &&
                     (string.IsNullOrEmpty(description) || x.movie.Description.ToLower().Contains(description.ToLower())) &&
                     (string.IsNullOrEmpty(showTime) || x.show.ShowTime == showTime))
                .Select(x => x.movie)
                .Distinct();

            IEnumerable<Movie> searchResults = query.ToList();

            return View(searchResults);

        }
    }
}
