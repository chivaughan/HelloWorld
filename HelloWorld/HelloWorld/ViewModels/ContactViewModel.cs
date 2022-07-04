using HelloWorld.Models;
using System;
using System.Collections.ObjectModel;
using System.IO;
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
        private IContactStore _contactStore;
        private readonly IPageService _pageService;
        public ICommand SelectContactCommand { get; private set; }
        public ICommand DeleteContactCommand { get; private set; }
        public ICommand GoToContactDetailsPageCommand { get; private set; }

        public ICommand LoadContactsCommand { get; private set; }
        public ContactViewModel(IContactStore contactStore, IPageService pageService)
        {
            // Set the default page title
            _pageTitle = "Add Contact";
            _pageService = pageService;
            _contactStore = contactStore;
            _contacts = new ObservableCollection<Contact>();
            SelectContactCommand = new Command<Contact>(async contact => await SelectContact(contact));
            DeleteContactCommand = new Command<Contact>(async contact => await DeleteContact(contact));
            LoadContactsCommand = new Command(async () => await LoadAllContacts());
            GoToContactDetailsPageCommand = new Command(GoToContactDetailsPage);
        }

        private async Task LoadAllContacts()
        {
            var loadedContacts = await _contactStore.LoadContactsAsync();
            Contacts = new ObservableCollection<Contact>(loadedContacts);
        }

        private async Task DeleteContact(Contact contact)
        {
            var response = await _pageService.DisplayAlert("Confirm Delete", "Are you sure you want to delete this contact?", "Yes", "No");
            if (response)
            {
                Contacts.Remove(contact);
                await _contactStore.DeleteContactAsync(contact);
            }
        }

        public async Task AddContact(string firstName, string lastName, string phone, string address, string email, 
            bool blockedStatus, string imageUrl, string contactGroup)
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

            await _contactStore.AddContactAsync(contact);
            await _pageService.DisplayAlert("Saved", "Contact saved", "Ok");
            await _pageService.PopAsync();
        }

        public async Task UpdateContact(Contact contact, string firstName, string lastName, 
            string phone, string address, string email, bool blockedStatus, string imageUrl, string contactGroup)
        {
            contact.FirstName = firstName;
            contact.LastName = lastName;
            contact.Phone = phone;
            contact.Address = address;
            contact.Email = email;
            contact.Blocked = blockedStatus;
            contact.ImageUrl = imageUrl;
            contact.ContactGroup = contactGroup;
            await _contactStore.UpdateContactAsync(contact);
            await _pageService.DisplayAlert("Saved", "Contact saved", "Ok");
            // Deselect the selected contact
            SelectedContact = null;
            await _pageService.PopAsync();
        }

        public async Task SaveContact(string firstName, string lastName, string phone, string address, 
            string email, bool blockedStatus, string imageUrl, string contactGroup)
        {
            if (String.IsNullOrWhiteSpace(firstName) || String.IsNullOrWhiteSpace(lastName))
            {
                await _pageService.DisplayAlert("Name Required", "First & last name is required", "Ok");
                return;
            }
            else
            {
                // Lets fetch the actual path for the imageurl
                // This is the path where our images were saved earlier in the Helper class
                // after the user selected a picture
                if (!String.IsNullOrEmpty(imageUrl) || !String.IsNullOrWhiteSpace(imageUrl))
                    imageUrl = Path.Combine(Xamarin.Essentials.FileSystem.CacheDirectory, Path.GetFileName(imageUrl));

                if (SelectedContact != null)
                {
                    // At this point, we know it is an update action
                    // Fetch the selected contact we have in the view model
                    // and update the contact's details
                    await UpdateContact(SelectedContact, firstName, lastName, phone, address, email, blockedStatus, imageUrl, contactGroup);
                }
                else
                {
                    // It is a new entry. So we add the contact
                    await AddContact(firstName, lastName, phone, address, email, blockedStatus, imageUrl, contactGroup);
                }
            }
        }
        private async void GoToContactDetailsPage()
        {
            PageTitle = "Add Contact";
            await _pageService.PushAsync(new ContactDetailsPage(this));
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

        private async Task SelectContact(Contact contact)
        {
            SelectedContact = contact;
            if (contact == null)
                return;
            // This is an Edit so we set the page title to 'Edit Contact'
            // and Navigate to the contact details page
            PageTitle = "Edit Contact";
            await _pageService.PushAsync(new ContactDetailsPage(this));
        }        

    }
}
