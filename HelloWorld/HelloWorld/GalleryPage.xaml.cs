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
    public partial class GalleryPage : ContentPage
    {
        List<string> images = new List<string>();
        int indexToMoveTo;
        public GalleryPage()
        {
            InitializeComponent();

            images = new List<string>() {
                "https://images.unsplash.com/photo-1480714378408-67cf0d13bc1b?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=2070&q=80",
            "https://images.unsplash.com/photo-1444084316824-dc26d6657664?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80",
            "https://images.unsplash.com/photo-1477959858617-67f85cf4f1df?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=944&q=80",
            "https://images.unsplash.com/photo-1543872084-c7bd3822856f?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=387&q=80",
            "https://images.unsplash.com/photo-1495954380655-01609180eda3?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=387&q=80"
            };
            
            image.Source = new UriImageSource 
            { 
                Uri = new Uri(images[0]),
                CachingEnabled = false
            };
            lblCurrentIndex.Text = images.IndexOf(images[0]).ToString();
            
        }

        private void btnNext_Clicked(object sender, EventArgs e)
        {
            images = new List<string>() {
                "https://images.unsplash.com/photo-1480714378408-67cf0d13bc1b?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=2070&q=80",
            "https://images.unsplash.com/photo-1444084316824-dc26d6657664?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80",
            "https://images.unsplash.com/photo-1477959858617-67f85cf4f1df?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=944&q=80",
            "https://images.unsplash.com/photo-1543872084-c7bd3822856f?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=387&q=80",
            "https://images.unsplash.com/photo-1495954380655-01609180eda3?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=387&q=80"
            };

            // Calculate the index to move to based on the current index
            indexToMoveTo = int.Parse(lblCurrentIndex.Text) + 1;

            // If the indexToMoveTo is <= (the list count - 1), we move to that index,
            // otherwise, start all over and move to the first item in the list
            if (indexToMoveTo <= (images.Count-1))
            {
                image.Source = new UriImageSource
                {
                    Uri = new Uri(images[indexToMoveTo]),
                    CachingEnabled = false
                };
                lblCurrentIndex.Text = images.IndexOf(images[indexToMoveTo]).ToString();
            }
            else
            {
                image.Source = new UriImageSource
                {
                    Uri = new Uri(images[0]),
                    CachingEnabled = false
                };
                lblCurrentIndex.Text = images.IndexOf(images[0]).ToString();
            }

            
        }

        private void btnPrevious_Clicked(object sender, EventArgs e)
        {
            images = new List<string>() {
                "https://images.unsplash.com/photo-1480714378408-67cf0d13bc1b?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=2070&q=80",
            "https://images.unsplash.com/photo-1444084316824-dc26d6657664?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80",
            "https://images.unsplash.com/photo-1477959858617-67f85cf4f1df?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=944&q=80",
            "https://images.unsplash.com/photo-1543872084-c7bd3822856f?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=387&q=80",
            "https://images.unsplash.com/photo-1495954380655-01609180eda3?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=387&q=80"
            };

            // Calculate the index to move to based on the current index
            indexToMoveTo = int.Parse(lblCurrentIndex.Text) - 1;

            // If the indexToMoveTo is >= 0, we move to that index,
            // otherwise, start all over and move to the last item in the list
            if (indexToMoveTo >= 0)
            {
                image.Source = new UriImageSource
                {
                    Uri = new Uri(images[indexToMoveTo]),
                    CachingEnabled = false
                };
                lblCurrentIndex.Text = images.IndexOf(images[indexToMoveTo]).ToString();
            }                
            else
            {
                image.Source = new UriImageSource
                {
                    Uri = new Uri(images[images.Count - 1]),
                    CachingEnabled = false
                };
                lblCurrentIndex.Text = images.IndexOf(images[images.Count - 1]).ToString();
            }
                
            
        }
    }
}