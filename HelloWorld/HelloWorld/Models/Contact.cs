using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
            set { }
        }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public bool Blocked { get; set; }

        public string ImageUrl { get; set; }

        public string ContactGroup { get; set; }
    }
}
