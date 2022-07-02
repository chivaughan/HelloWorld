using HelloWorld.Models.Movie;
using HelloWorld.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Xamarin.Forms;

namespace HelloWorld.ViewModels
{
    public class MoviesViewModel: BaseViewModel
    {
        private ObservableCollection<Movie> _movies;
        private bool _hasMovies;
        private Movie _selectedMovie;

        private readonly IPageService _pageService;
        public MoviesViewModel(IPageService pageService)
        {
            _pageService = pageService;
        }
        public ObservableCollection<Movie> Movies
        {
            get { return _movies; }
            set { SetValue(ref _movies, value); }
        }
                
        public bool HasMovies
        {
            get { return _hasMovies; }
            set { SetValue(ref _hasMovies, value); }
        }
        
        public Movie SelectedMovie
        {
            get {return _selectedMovie;}
            set { SetValue(ref _selectedMovie, value); }
        }

        public async void SearchMoviesAPI(bool includeAdultMovies, string movieTitle)
        {
            try
            {
                // We should only perform the search when the user types at least 5 characters
                if (!String.IsNullOrWhiteSpace(movieTitle) && movieTitle.Length >= 5)
                {
                    // Fetch the Uri and api key then set the query parameter
                    var builder = new UriBuilder(Helper.MovieRequestUri);
                    var query = HttpUtility.ParseQueryString(builder.Query);
                    query["api_key"] = Helper.MovieAPI_Key;
                    query["include_adult"] = includeAdultMovies.ToString();

                    query["query"] = movieTitle;

                    builder.Query = query.ToString();
                    string url = builder.ToString();

                    // Use the Http Client to get the result
                    var client = new HttpClient();
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri(url),
                    };
                    using (var response = await client.SendAsync(request))
                    {
                        response.EnsureSuccessStatusCode();
                        var body = await response.Content.ReadAsStringAsync();
                        var rootObject = JsonConvert.DeserializeObject<Rootobject>(body);
                        Movies = new ObservableCollection<Movie>(rootObject.results);

                        if (Movies.Count() == 0)
                        {
                            // Set the flag to false and do nothing since no such movie was found. Just return
                            // Let the user change his search query
                            HasMovies = false;
                            return;
                        }

                        HasMovies = true;
                    }
                }
            }
            catch (Exception ex)
            {
                await _pageService.DisplayAlert("Error", "An error occurred", "Cancel");
            }

        }

        
        public void SelectMovie(Movie movie)
        {
            if (movie == null)
                return;
            SelectedMovie = null;
            _pageService.PushAsync(new MovieDetailsPage(movie));
        }
    }
}
