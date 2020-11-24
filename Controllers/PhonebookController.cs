using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhonesBook.ApiModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhonesBook.Controllers
{
    [Route("api/[controller]")]
    public class PhonebookController : Controller
    {
        public PhonebookController(IPhonebookRepository phonebookItem)
        {
            PhonebookItem = phonebookItem;
        }
        public IPhonebookRepository PhonebookItem { get; set; }

        public IEnumerable<PhonebookItem> GetAll()
        {
            return PhonebookItem.GetAll();
        }

    }
}
