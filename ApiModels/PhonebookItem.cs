using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhonesBook.ApiModels
{
    public class PhonebookItem
    {
        public Guid ContactId { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsAdded { get; set; }
    }
}
