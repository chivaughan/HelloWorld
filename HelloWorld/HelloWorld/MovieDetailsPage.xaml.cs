using HelloWorld.Models;
using HelloWorld.Models.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace HelloWorld
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieDetailsPage : ContentPage
    {
        public MovieDetailsPage(Movie movie)
        {
            if (movie == null)
                return;
            BindingContext = movie;
            InitializeComponent();
        }
    }
}