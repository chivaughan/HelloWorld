using HelloWorld.Models;
using HelloWorld.Models.Movie;
using HelloWorld.Services;
using HelloWorld.ViewModels;
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
        public MoviesPage()
        {
            BindingContext = new MoviesViewModel(new PageService());
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        
        private void lstMovies_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            (BindingContext as MoviesViewModel).SelectMovie(e.SelectedItem as Movie);
        }

        private void searchMovies_TextChanged(object sender, TextChangedEventArgs e)
        {
            (BindingContext as MoviesViewModel).SearchMoviesAPI(switchAdult.IsToggled ,e.NewTextValue);
        }

        private void switchAdult_Toggled(object sender, ToggledEventArgs e)
        {
            (BindingContext as MoviesViewModel).SearchMoviesAPI(switchAdult.IsToggled, searchMovies.Text);
        }
    }
}