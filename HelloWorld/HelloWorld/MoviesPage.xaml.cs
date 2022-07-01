using HelloWorld.Models;
using HelloWorld.Models.Movie;
using HelloWorld.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace HelloWorld
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoviesPage : ContentPage
    {
        private ObservableCollection<Result> _movies;
        public MoviesPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            
            base.OnAppearing();
        }

        private async void SearchMoviesAPI(string movieTitle = null)
        {
            try
            {
                // Fetch the Uri and api key then set the query parameter
                var builder = new UriBuilder(Helper.MovieRequestUri);
                var query = HttpUtility.ParseQueryString(builder.Query);
                query["api_key"] = Helper.MovieAPI_Key;
                query["include_adult"] = switchAdult.IsToggled.ToString();

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
                    _movies = new ObservableCollection<Result>(rootObject.results);

                    if (_movies.Count() == 0)
                    {
                        // Do nothing since the movie no such movie was found. Just return
                        // Let the user change his search query
                        return;
                    }

                    lstMovies.ItemsSource = _movies;
                    lblNumberOfMovies.Text = _movies.Count().ToString() + " movies found";                    
                    lstMovies.IsVisible = true;
                    lblNoMovies.IsVisible = false;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "An error occurred", "Cancel");
            }
            
        }
        private void lstMovies_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (lstMovies.SelectedItem == null)
                return;
            var movie = lstMovies.SelectedItem as Result;
            Navigation.PushAsync(new MovieDetailsPage(movie));
            lstMovies.SelectedItem = null;
        }

        private void searchMovies_TextChanged(object sender, TextChangedEventArgs e)
        {
            // We should only perform the search when the user types at least 5 characters
            if (e.NewTextValue.Length >=5)
                SearchMoviesAPI(e.NewTextValue);
        }

        private void switchAdult_Toggled(object sender, ToggledEventArgs e)
        {
            // We should only perform the search when the user types at least 5 characters
            if (searchMovies.Text.Length >= 5)
                SearchMoviesAPI(searchMovies.Text);
        }
    }
}