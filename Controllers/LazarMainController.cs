using LazarNetMVCApp.Models;
using Microsoft.AspNetCore.Mvc;
using TMDbLib.Client;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.Search;
using System.Net.Http.Json;

namespace LazarNetMVCApp.Controllers
{
    public class LazarMainController : Controller {
        const string superheroConnection = "https://www.superheroapi.com/api/2642715652525988/";
        public TMDbClient client = new TMDbClient("923ba34a720eb4f615326820215f419d");        
        public static readonly HttpClient superheroClient = new HttpClient();
        
        public IActionResult Index() {
            Movie apiMovie = searchForExactMovie("Spider-Man");
            Video apiMovieTrailer = getVideos(apiMovie.Id);

            Task<ApiSuperheroViewModel> tempSuperheroInfo = getHeroByName("batman");
            Result apiSuperheroResult = tempSuperheroInfo.Result.results[0];
            SuperheroViewModel superhero = new SuperheroViewModel(apiSuperheroResult.id, apiSuperheroResult.name, apiSuperheroResult.powerstats.intelligence, apiSuperheroResult.powerstats.strength,
                apiSuperheroResult.powerstats.speed, apiSuperheroResult.powerstats.durability, apiSuperheroResult.powerstats.power, apiSuperheroResult.powerstats.combat,
                apiSuperheroResult.biography.fullname, apiSuperheroResult.biography.alteregos, apiSuperheroResult.biography.aliases, apiSuperheroResult.biography.placeofbirth,
                apiSuperheroResult.biography.firstappearance, apiSuperheroResult.biography.publisher, apiSuperheroResult.biography.alignment, apiSuperheroResult.appearance.gender,
                apiSuperheroResult.appearance.race, apiSuperheroResult.appearance.height, apiSuperheroResult.appearance.weight, apiSuperheroResult.appearance.eyecolor,
                apiSuperheroResult.appearance.haircolor, apiSuperheroResult.work.occupation, apiSuperheroResult.work._base, apiSuperheroResult.connections.groupaffiliation,
                apiSuperheroResult.connections.relatives, apiSuperheroResult.image.url);

            ApiSuperheroViewModel apiSuperhero = new ApiSuperheroViewModel(getHeroInfo(apiSuperheroResult));
            LazarViewModel lazarModel = new LazarViewModel(0, apiMovie.Id, apiMovie.Title, apiMovie.PosterPath, apiMovie.ReleaseDate.Value, apiMovie.Overview, apiMovie.VoteAverage, apiMovieTrailer, apiMovieTrailer.Key);

            return View(superhero);
        }
        public Video getVideos(int movieId) {
            ResultContainer<Video> videos = client.GetMovieVideosAsync(movieId).Result;
            return videos.Results[0];
        }
        public Movie searchForExactMovie(String movieName) {
            SearchContainer<SearchMovie> searchMovie = client.SearchMovieAsync(movieName).Result;
            return client.GetMovieAsync(searchMovie.Results[0].Id).Result;
        }

        public static async Task<ApiSuperheroViewModel> getHeroByName(String superhero) {
            ApiSuperheroViewModel superHeroInfo = null;
            String searchByName = superheroConnection + "search/" + superhero;
            HttpRequestMessage searchByNameRequest = new HttpRequestMessage(HttpMethod.Get, searchByName);
            try {
                HttpResponseMessage response = await superheroClient.SendAsync(searchByNameRequest);
                if(response.IsSuccessStatusCode) {
                    superHeroInfo = await response.Content.ReadFromJsonAsync<ApiSuperheroViewModel>();
                }
                else {
                    Console.WriteLine(response.ReasonPhrase);
                }
            }
            catch (HttpRequestException e) {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            return superHeroInfo;
        }
        public static String getHeroInfo(Result superHeroProperties) {
            String info = "";
            
            return info;
        }
    }
}