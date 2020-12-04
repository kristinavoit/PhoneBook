using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhonesBook.ApiModels
{
    public class EditContactDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool CheckNull { get; set; }
    }
}
