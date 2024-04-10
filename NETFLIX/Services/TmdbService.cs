using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TmdbService
    {
        private const string ApiKey = "738b6d8d99b51339705b1037c981a488"; // generate it from tmdb website
        public const string TmdbHttpClientName = "TmdbClient";
        private readonly IHttpClientFactory _httpClientFactory;

        public TmdbService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        private HttpClient HttpClient => _httpClientFactory.CreateClient(TmdbHttpClientName);

    }
    public static class TmdbUrls
    {
        public const string Trending = "3/trending/all/week?language=en-US";
        public const string NetflixOriginals = "3/discover/tv?language=en-US&with_networks=213";
        public const string TopRated = "3/movie/top_rated?language=en-US";
        public const string Action = "3/discover/movie?language=en-US&with_genres=28";

        public static string GetTrailers(int movieId, string type = "movie") => $"3/{type ?? "movie"}/{movieId}/videos?language=en-US";

        public static string GetMovideDetails(int movieId, string type = "movie") => $"3/{type ?? "movie"}/{movieId}/videos?language=en-US";

        public static string GetSimilar(int movieId, string type = "movie") => $"3/{type ?? "movie"}/{movieId}/similar?language=en-US";
    }
}
