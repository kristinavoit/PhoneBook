using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhonesBook.ApiModels
{
    public class EditContactDTO
    {
        public int Id { get; set; }
        public string ContactName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
