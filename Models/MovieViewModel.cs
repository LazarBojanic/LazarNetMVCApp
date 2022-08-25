using TMDbLib.Objects.Movies;

namespace LazarNetMVCApp.Models {
    public class MovieViewModel {
        public int id { get; set; }
        public int movieId { get; set; }
        public String? movieTitle { get; set; }
        public DateTime? movieReleaseDate { get; set; }
        public String? movieOverview { get; set; }
        public double movieVoteAverage { get; set; }

        public MovieViewModel(int id, int movieId, string? movieTitle, DateTime? movieReleaseDate, string? movieOverview, double movieVoteAverage) {
            this.id = id;
            this.movieId = movieId;
            this.movieTitle = movieTitle;
            this.movieReleaseDate = movieReleaseDate;
            this.movieOverview = movieOverview;
            this.movieVoteAverage = movieVoteAverage;
        }
    }
}
