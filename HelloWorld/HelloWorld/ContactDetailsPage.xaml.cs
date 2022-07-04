using HelloWorld.Models;
using HelloWorld.Persistence;
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
            // This will help us deselect the listview
            ViewModel.SelectedContact = null;            
            ViewModel.Contacts = new ObservableCollection<Contact>(ViewModel.Contacts);
            base.OnDisappearing();
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
                if (ViewModel.SelectedContact != null)
                {
                    // At this point, we know it is an update action
                    // Fetch the selected contact we have in the view model
                    // and update the contact's details
                    await ViewModel.UpdateContact(ViewModel.SelectedContact, FirstName.Text, LastName.Text, Phone.Text, Address.Text, Email.Text, Blocked.On, helper.FetchRandomImageUrl(), ContactGroup.Text);
                }
                else
                {
                    // It is a new entry. So we add the contact
                    await ViewModel.AddContact(FirstName.Text, LastName.Text, Phone.Text, Address.Text, Email.Text, Blocked.On, helper.FetchRandomImageUrl(), ContactGroup.Text);
                }
            }

        }

        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            //MessagingCenter.Subscribe<ContactGroupPage>(this,"SelectedContactGroup",SelectContactGroup(this,)
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
    }
}