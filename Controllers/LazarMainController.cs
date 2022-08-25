using LazarNetMVCApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using TMDbLib.Client;
using TMDbLib.Objects.Collections;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.Search;

namespace LazarNetMVCApp.Controllers {
    public class LazarMainController : Controller {
        TMDbClient client = new TMDbClient("923ba34a720eb4f615326820215f419d");
        public IActionResult Index() {      
            Movie apiMovie = searchForExactMovie("Spider-Man");
            Video apiMovieTrailer = getVideos(apiMovie.Id);
            MovieViewModel movie = new MovieViewModel(0, apiMovie.Id, apiMovie.Title, apiMovie.PosterPath, apiMovie.ReleaseDate, apiMovie.Overview, apiMovie.VoteAverage, apiMovieTrailer, apiMovieTrailer.Key);
            return View(movie);
        }
        public Video getVideos(int movieId) {
            ResultContainer<Video> videos = client.GetMovieVideosAsync(movieId).Result;
            return videos.Results[0];
        }
        public Movie searchForExactMovie(String movieName) {
            SearchContainer<SearchMovie> searchMovie = client.SearchMovieAsync(movieName).Result;
            return client.GetMovieAsync(searchMovie.Results[0].Id).Result;
        }
    }
}