using HelloWorld.Models;
using HelloWorld.Services;
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
        private ContactService _contactService = new ContactService();
        private ObservableCollection<Contact> _contacts =  new ObservableCollection<Contact>();
        
        public ContactsPage()
        {
            InitializeComponent();
            _contacts = _contactService.GetAllContacts();
            lstContacts.ItemsSource = _contacts;
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var contact = menuItem.CommandParameter as Contact;
            var response = await DisplayAlert("Confirm Delete", "Are you sure you want to delete this contact?", "Yes", "No");
            if (response)
                _contacts.Remove(contact);
        }

        private void btnAddContact_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ContactDetailsPage());
        }

        private void lstContacts_Refreshing(object sender, EventArgs e)
        {
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