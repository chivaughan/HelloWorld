using HelloWorld.Models;
using HelloWorld.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HelloWorld.ViewModels
{
    public class ContactViewModel : BaseViewModel
    {
        private ObservableCollection<Contact> _contacts;
        private Contact _selectedContact;
        private string _pageTitle;
        private SQLiteAsyncConnection _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        private readonly IPageService _pageService;
        public ICommand SelectContactCommand { get; private set; }
        public ICommand DeleteContactCommand { get; private set; }
        public ICommand GoToContactDetailsPageCommand { get; private set; }

        public ICommand LoadContactsCommand { get; private set; }
        public ContactViewModel(IPageService pageService)
        {
            // Set the default page title
            _pageTitle = "Add Contact";
            _pageService = pageService;
            _contacts = new ObservableCollection<Contact>();
            SelectContactCommand = new Command<Contact>(async contact => await SelectContact(this, contact));
            DeleteContactCommand = new Command<Contact>(async contact => await DeleteContact(contact));
            LoadContactsCommand = new Command(LoadContacts);
            GoToContactDetailsPageCommand = new Command(GoToContactDetailsPage);
        }

        private async void GoToContactDetailsPage()
        {
           await _pageService.PushAsync(new ContactDetailsPage());
        }
        public ObservableCollection<Contact> Contacts
        {
            get { return _contacts; }
            set { SetValue(ref _contacts, value); }
        }        

        public Contact SelectedContact
        {
            get { return _selectedContact; }
            set { SetValue(ref _selectedContact, value); }
        }

        public string PageTitle
        {
            get { return _pageTitle; }
            set { SetValue(ref _pageTitle, value); }
        }

        private async void LoadContacts()
        {
            await _connection.CreateTableAsync<Contact>();
            var contacts = await _connection.Table<Contact>().ToListAsync();
            Contacts = new ObservableCollection<Contact>(contacts);
        }

        private async Task SelectContact(ContactViewModel viewModel, Contact contact)
        {
            SelectedContact = contact;
            if (contact == null)
                return;
            // This is an Edit so we set the page title to 'Edit Contact'
            // and Navigate to the contact details page
            PageTitle = "Edit Contact";
            await _pageService.PushAsync(new ContactDetailsPage(viewModel));
        }

        private async Task DeleteContact(Contact contact)
        {
            var response = await _pageService.DisplayAlert("Confirm Delete", "Are you sure you want to delete this contact?", "Yes", "No");
           if (response)
            {
                Contacts.Remove(contact);
                await _connection.DeleteAsync(contact);
            }
        }

        public async Task AddContact(string firstName, string lastName, string phone, string address,
            string email, bool blockedStatus, string imageUrl, string contactGroup)
        {
            Contact contact = new Contact
            {
                FirstName = firstName,
                LastName = lastName,
                Phone = phone,
                Address = address,
                Email = email,
                Blocked = blockedStatus,
                ImageUrl = imageUrl,
                ContactGroup = contactGroup
            };

            Contacts.Add(contact);
                        
            await _connection.InsertAsync(contact);
            await _pageService.DisplayAlert("Saved", "Contact saved", "Ok");
            await _pageService.PopAsync();
        }

        public async Task UpdateContact(Contact contact, 
            string firstName, string lastName, string phone, string address, 
            string email, bool blockedStatus,string imageUrl,string contactGroup)
        {
            contact.FirstName = firstName;
            contact.LastName = lastName;
            contact.Phone = phone;
            contact.Address = address;
            contact.Email = email;
            contact.Blocked = blockedStatus;
            contact.ImageUrl = imageUrl;
            contact.ContactGroup = contactGroup;
            await _connection.UpdateAsync(contact);
            await _pageService.DisplayAlert("Saved", "Contact saved", "Ok");
            await _pageService.PopAsync();

            // Update the Contacts in the collection
            // so that the updated record can be reflected in the contacts page listview
            Contacts = new ObservableCollection<Contact>(Contacts);
        }

    }
}
