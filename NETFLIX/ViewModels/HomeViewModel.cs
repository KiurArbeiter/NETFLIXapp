using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Netflix.Models;
using Netflix.Services;
using System.Collections.ObjectModel;

namespace Netflix.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        private readonly TmdbService _tmdbService;
        public HomeViewModel(TmdbService tmdbService)
        {
            _tmdbService = tmdbService;
        }

        [ObservableProperty]
        private Media _trendingMovie;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(ShowMovieInfoBox))]
        private Media? _selectedMedia;

        public bool ShowMovieInfoBox => SelectedMedia is not null;

        public ObservableCollection<Media> Trending { get; set; } = new();
        public ObservableCollection<Media> TopRated { get; set; } = new();
        public ObservableCollection<Media> NetflixOriginals { get; set; } = new();
        public ObservableCollection<Media> ActionMovies { get; set; } = new();

        public async Task InitializeAsync()
        {
            var trendingList = await _tmdbService.GetTrendingList();
            if (trendingList?.Any() == true)
            {
                foreach (var trending in trendingList)
                {
                    Trending.Add(trending);
                }
            }

            var netflixOriginals = await _tmdbService.GetNetflixOriginalAsync();
        }

    }
}
