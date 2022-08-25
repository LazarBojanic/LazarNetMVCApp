using LazarNetMVCApp.Models;
using Microsoft.AspNetCore.Mvc;
using TMDbLib.Client;
using TMDbLib.Objects.Movies;

namespace LazarNetMVCApp.Controllers {
    public class LazarMainController : Controller {
        public IActionResult Index() {
            TMDbClient client = new TMDbClient("923ba34a720eb4f615326820215f419d");
            Movie apiMovie = client.GetMovieAsync(47964).Result;
            MovieViewModel movie = new MovieViewModel(0, apiMovie.Id, apiMovie.Title, apiMovie.ReleaseDate, apiMovie.Overview, apiMovie.VoteAverage);
            return View(movie);
        }
    }
}
