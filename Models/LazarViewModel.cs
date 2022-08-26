using TMDbLib.Objects.General;
using TMDbLib.Objects.Movies;
using static System.Net.WebRequestMethods;

namespace LazarNetMVCApp.Models {
    public class LazarViewModel {
        public int id { get; set; }
        public int movieId { get; set; }
        public String movieTitle { get; set; }
        public String moviePoster { get; set; }
        public DateTime movieReleaseDate { get; set; }
        public String movieOverview { get; set; }
        public double movieVoteAverage { get; set; }
        public Video movieTrailer { get; set; }
        public String movieTrailerUrl { get; set; }

        public LazarViewModel(int id, int movieId, string movieTitle, string moviePoster, DateTime movieReleaseDate, string movieOverview, double movieVoteAverage, Video movieTrailer, string movieTrailerUrl) {
            this.id = id;
            this.movieId = movieId;
            this.movieTitle = movieTitle;
            this.moviePoster = "https://image.tmdb.org/t/p/w500/" + moviePoster;
            this.movieReleaseDate = movieReleaseDate;
            this.movieOverview = movieOverview;
            this.movieVoteAverage = movieVoteAverage;
            this.movieTrailer = movieTrailer;
            this.movieTrailerUrl = "https://www.youtube.com/embed/" + movieTrailer.Key;
        }
    }
}