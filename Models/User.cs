using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PhonesBook.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public bool IsAdmin { get; set; }
    }
}
