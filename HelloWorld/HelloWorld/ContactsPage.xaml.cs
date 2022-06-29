using HelloWorld.Models;
using HelloWorld.Services;
using SQLite;
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
    public partial class ContactsPage : ContentPage
    {
        private ObservableCollection<Contact> _contacts;
        private SQLiteAsyncConnection _connection;
        bool _firstLoad;
        public ContactsPage()
        {
            InitializeComponent();
            _firstLoad = true;
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        protected override async void OnAppearing()
        {
            // We should execute the connection async actions here if this is the first load
            // After this execution, we should set the flag to false
            if (_firstLoad)
            {
                await _connection.CreateTableAsync<Contact>();
                var contacts = await _connection.Table<Contact>().ToListAsync();
                _contacts = new ObservableCollection<Contact>(contacts);
                lstContacts.ItemsSource = _contacts;

                // Set the flag to false
                _firstLoad = false;
            }            

            base.OnAppearing();
        }
        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var contact = menuItem.CommandParameter as Contact;
            var response = await DisplayAlert("Confirm Delete", "Are you sure you want to delete this contact?", "Yes", "No");
            if (response)
            {
                _contacts.Remove(contact);
                await _connection.DeleteAsync(contact);
            }              
                
        }

        private void btnAddContact_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ContactDetailsPage());
        }

        private async void lstContacts_Refreshing(object sender, EventArgs e)
        {
            var contacts = await _connection.Table<Contact>().ToListAsync();

            _contacts = new ObservableCollection<Contact>(contacts);
            lstContacts.ItemsSource = _contacts;
            lstContacts.EndRefresh();
        }

        private void lstContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (lstContacts.SelectedItem == null)
                return;
            var contact = lstContacts.SelectedItem as Contact;
            Navigation.PushAsync(new ContactDetailsPage(contact));
            lstContacts.SelectedItem = null;
        }

        
    }
}