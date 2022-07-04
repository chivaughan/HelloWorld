using HelloWorld.Models;
using HelloWorld.Services;
using HelloWorld.ViewModels;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactDetailsPage : ContentPage
    {
        Helper helper = new Helper();
        public ContactViewModel ViewModel
        {
            get { return BindingContext as ContactViewModel; }
            set { BindingContext = value; }
        }

        public ContactDetailsPage(ContactViewModel contactViewModel)
        {
            if (contactViewModel == null)
                throw new ArgumentNullException(nameof(contactViewModel));
            ViewModel = contactViewModel;
            InitializeComponent();
        }
        
        protected override void OnDisappearing()
        {
            // Refresh the contacts in the view model by making a fresh copy
            ViewModel.Contacts = new ObservableCollection<Contact>(ViewModel.Contacts);
            base.OnDisappearing();
        }
        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            await ViewModel.SaveContact(FirstName.Text, LastName.Text, Phone.Text, Address.Text, Email.Text, Blocked.On, Image.Source.ToString(), ContactGroup.Text);
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

        private void SelectContactGroup(ContactDetailsPage page, string selectedContactGroup)
        {
            ContactGroup.Text = selectedContactGroup;
        }

        private async void btnPhoto_Clicked(object sender, EventArgs e)
        {
            Image.Source = await helper.TakePhotoAsync();                    
        }
    }
}