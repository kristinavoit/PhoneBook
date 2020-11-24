using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhonesBook.ApiModels
{
    public class PhonebookItem
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public bool IsAdded { get; set; }
    }
}
