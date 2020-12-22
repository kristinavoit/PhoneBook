using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PhonesBook.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string ContactName { get; set; }
        public string PhoneNumber { get; set; }
        public string CountryName { get; set; }
        public int UserId { get; set; }

    }
}
