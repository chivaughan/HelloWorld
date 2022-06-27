using HelloWorld.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookingsPage : ContentPage
    {
        ObservableCollection<Booking> _bookings;
        public BookingsPage()
        {
            InitializeComponent();
            
            _bookings = new ObservableCollection<Booking>();
            lstBookings.ItemsSource = GetBookings();
        }

        private ObservableCollection<Booking> GetBookings(string searchQuery = null)
        {
            _bookings = new ObservableCollection<Booking>() { };

            _bookings.Add(new Booking
            {
                Id = 1,
                Customer = new Customer() { Name = "Chinedu", Id = 1, Age = 31, Gender = "Male" },
                StreetAddress = "20 Admiralty Way, Lekki",
                City = "Lagos",
                State = "Lagos",
                StateCode = "LOS",
                Country = "Nigeria",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(23),
                ImageUrl = "https://images.unsplash.com/photo-1480714378408-67cf0d13bc1b?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=2070&q=80"
                
                
            });
            _bookings.Add(new Booking
            {
                Id = 2,
                Customer = new Customer() { Name = "Nkechi", Id = 2, Age = 33, Gender = "Female" },
                StreetAddress = "2678 Davis Street",
                City = "Augusta",
                State = "Georgia",
                StateCode = "GA",
                Country = "United States of America",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(13),
                ImageUrl = "https://images.unsplash.com/photo-1444084316824-dc26d6657664?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80"

            });
            _bookings.Add(new Booking
            {
                Id = 3,
                Customer = new Customer() { Name = "Chinecherem", Id = 3, Age = 24, Gender = "Female" },
                StreetAddress = "2182 Franklee Lane",
                City = "Philadelphia",
                State = "Pennsylvania",
                StateCode = "PA",
                Country = "United States of America",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(3),
                ImageUrl = "https://images.unsplash.com/photo-1477959858617-67f85cf4f1df?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=944&q=80"

            });
            _bookings.Add(new Booking
            {
                Id = 4,
                Customer = new Customer() { Name = "Obinna", Id = 4, Age = 19, Gender = "Male" },
                StreetAddress = "280 Barnes Street",
                City = "Winter Park",
                State = "Florida",
                StateCode = "FL",
                Country = "United States of America",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(43),
                ImageUrl = "https://images.unsplash.com/photo-1543872084-c7bd3822856f?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=387&q=80"

            });

            if (String.IsNullOrWhiteSpace(searchQuery))
                return _bookings;
            else
            {
                ObservableCollection<Booking> fetchedBookings = new ObservableCollection<Booking>();
                fetchedBookings = _bookings.Where(x => x.StreetAddress.ToLower().StartsWith(searchQuery.ToLower())) as ObservableCollection<Booking>;
                return fetchedBookings;
            }
            
        }

        private void lstBookings_Refreshing(object sender, EventArgs e)
        {
            lstBookings.ItemsSource = GetBookings();

            lstBookings.EndRefresh();
        }

        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var booking = menuItem.CommandParameter as Booking;
            // Delete the selected booking
            _bookings.Remove(booking);
        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            lstBookings.ItemsSource = GetBookings(e.NewTextValue);
        }
    }
}