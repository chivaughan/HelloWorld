using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld.Models
{
    internal class Booking
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }

        public string Country { get; set; }

        public string State { get; set; }
        public string StateCode { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }

        public string ImageUrl { get; set; }   
        
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        
    }
}
