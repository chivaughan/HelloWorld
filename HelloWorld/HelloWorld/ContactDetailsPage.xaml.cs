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
    public partial class ContactDetailsPage : ContentPage
    {
        private SQLiteAsyncConnection _connection;

        // This contructor will be used to load contact details to be edited
        public ContactDetailsPage(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException("contact");
            BindingContext = contact;
            InitializeComponent();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            this.Title = "Edit Contact";
        }

        /// <summary>
        /// This constructor should be used to load the page to create new contacts
        /// </summary>
        public ContactDetailsPage()
        {
            InitializeComponent();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            this.Title = "Add Contact";
        }
        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(FirstName.Text) || String.IsNullOrWhiteSpace(LastName.Text))
            {
                await DisplayAlert("Name Required", "First & last name is required", "Ok");
                return;
            }
            else
            {
                if (BindingContext != null)
                {
                    // At this point, we know it is an update action
                    Contact contact = this.BindingContext as Contact;
                    Helper helper = new Helper();
                    contact.FirstName = FirstName.Text;
                    contact.LastName = LastName.Text;
                    contact.Phone = Phone.Text;
                    contact.Address = Address.Text;
                    contact.Email = Email.Text;
                    contact.Blocked = Blocked.On;
                    contact.ImageUrl = helper.FetchRandomImageUrl();
                    contact.ContactGroup = ContactGroup.Text;
                    await _connection.UpdateAsync(contact);
                    await DisplayAlert("Saved", "Contact saved", "Ok");
                    await Navigation.PopAsync();
                }
                else
                {
                    // It is a new entry
                    Helper helper = new Helper();
                    Contact contact = new Contact
                    {
                        FirstName = FirstName.Text,
                        LastName = LastName.Text,
                        Phone = Phone.Text,
                        Address = Address.Text,
                        Email = Email.Text,
                        Blocked = Blocked.On,
                        ImageUrl = helper.FetchRandomImageUrl(),
                        ContactGroup = ContactGroup.Text
                    };

                    await _connection.InsertAsync(contact);
                    await DisplayAlert("Saved", "Contact saved", "Ok");
                    await Navigation.PopAsync();
                }
            }
                
            
        }

        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            var page = new ContactGroupsPage();
            page.ContactGroups.SelectedItem = ContactGroup.Text;
            page.ContactGroups.ItemSelected += (source, args) =>
            {
                ContactGroup.Text = args.SelectedItem.ToString();
                Navigation.PopAsync();
            };
            Navigation.PushAsync(page);
        }
    }
}