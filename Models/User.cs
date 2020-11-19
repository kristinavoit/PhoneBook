using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PhonesBook.Models
{
    public class User
    {
        public int userID { get; set; }
        public string userName { get; set; }
        public bool isAdmin { get; set; }
    }
}
