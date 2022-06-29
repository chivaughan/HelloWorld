using HelloWorld.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace HelloWorld.Services
{
    public class ContactService
    {
        
        public ObservableCollection<Contact> GetAllContacts()
        {
            Helper helper = new Helper();
            ObservableCollection<Contact> contacts = new ObservableCollection<Contact>
            {
                new Contact
                {
                    Id = 1,
                    FirstName = "Chinedu",
                    LastName = "Obi",
                    Phone= "103845647383828",
                    Email = "chinedu@devasol.com",
                    Address= "Lagos, Nigeria",
                    Blocked = false,
                    ImageUrl = helper.FetchRandomImageUrl(),
                    ContactGroup = "Family"
                },
                new Contact
                {
                    Id = 2,
                    FirstName = "Nkechi",
                    LastName = "Obi",
                    Phone= "876545434556",
                    Email = "nkechi@devasol.com",
                    Address= "Atlanta, Georgia",
                    Blocked = false,
                    ImageUrl = helper.FetchRandomImageUrl(),
                    ContactGroup = "Friends"
                },
                new Contact
                {
                    Id = 3,
                    FirstName = "Esther",
                    LastName = "Anyaora",
                    Phone= "9087865678",
                    Email = "esther@devasol.com",
                    Address= "New York, USA",
                    Blocked = true,
                    ImageUrl = helper.FetchRandomImageUrl(),
                    ContactGroup = "Work"
                },
                new Contact
                {
                    Id = 4,
                    FirstName = "Chioma",
                    LastName = "Onyeka",
                    Phone= "7566793920",
                    Email = "chioma@devasol.com",
                    Address= "Paris, France",
                    Blocked = true,
                    ImageUrl = helper.FetchRandomImageUrl(),
                    ContactGroup = "Family"
                },
                new Contact
                {
                    Id = 5,
                    FirstName = "Chidiebere",
                    LastName = "Nwachukwu",
                    Phone= "777888666533",
                    Email = "chidiebere@devasol.com",
                    Address= "Ontario, Canada",
                    Blocked = false,
                    ImageUrl = helper.FetchRandomImageUrl(),
                    ContactGroup = "Friends"
                },
                new Contact
                {
                    Id = 6,
                    FirstName = "Obinna",
                    LastName = "Obi",
                    Phone= "+100099988844432",
                    Email = "obinna@devasol.com",
                    Address= "Washington DC, USA",
                    Blocked = false,
                    ImageUrl = helper.FetchRandomImageUrl(),
                    ContactGroup = "School"
                },
                new Contact
                {
                    Id = 7,
                    FirstName = "Ifeoma",
                    LastName = "Obi",
                    Phone= "533443772929",
                    Email = "ifeoma@devasol.com",
                    Address= "London, UK",
                    Blocked = true,
                    ImageUrl = helper.FetchRandomImageUrl(),
                    ContactGroup = "School"
                },
                new Contact
                {
                    Id = 8,
                    FirstName = "Chizoba",
                    LastName = "Obi",
                    Phone= "88772253637472828",
                    Email = "chizoba@devasol.com",
                    Address= "Barcelona, Spain",
                    Blocked = false,
                    ImageUrl = helper.FetchRandomImageUrl(),
                    ContactGroup = "Work"
                }
            };
            return contacts;
        }

        public Contact FetchRandomContact()
        {
            int contactsCount = GetAllContacts().Count();
            Random rand = new Random();
            int randomIndex = rand.Next(contactsCount);
            Contact contact = GetAllContacts()[randomIndex];
            return contact;
        }
    }
}
