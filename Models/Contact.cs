using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PhonesBook.Models
{
    public class Contact
    {
        public int contactID { get; set; }
        public string contactName { get; set; }
        public string phoneNumber { get; set; }
    }
}
