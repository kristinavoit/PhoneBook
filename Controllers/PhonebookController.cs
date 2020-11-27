using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhonesBook.ApiModels;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhonesBook.Controllers
{
    [Route("api/[controller]")]
    public class PhonebookController : Controller
    {
        IRepository repo;
        public PhonebookController(IRepository phonebookItem)
        {
            PhonebookItem = phonebookItem;
            repo = new phonebookItem();
        }
        public IRepository PhonebookItem { get; set; }

        public IEnumerable<PhonebookItem> GetAll()
        {
            return PhonebookItem.GetAll();
        }

        [HttpPost]
        public ActionResult Add([FromBody]AddContactViewModel model)
        {
            if (ModelState.IsValid){
                var config = new MapperConfiguration(cfg => cfg.CreateMap<AddContactViewModel, PhonebookItem>()
                    .ForMember("Key", opt => opt.MapFrom(c => c.Id))
                    .ForMember("Name", opt => opt.MapFrom(c => c.Name))
                    .ForMember("Login", opt => opt.MapFrom(c => c.Email))
                    .ForMember("PhoneNumber", opt => opt.MapFrom(c => c.PhoneNumber))
                    .ForMember("IsAdded", opt => opt.MapFrom(c => c.CheckNull)));
                config.AssertConfigurationIsValid();// to check automapper
                var mapper = new Mapper(config);

                PhonebookItem item = mapper.Map<AddContactViewModel, PhonebookItem>(model);
                repo.Add(item);
                repo.Save(item);
                return RedirectToAction("GetAll");

            }
            return View(model);
        }

        [HttpPut("{key}")]
        public ActionResult Edit(string key, [FromBody]EditContactViewModel model)
        {
            if (key == null )
            {
                return NotFound();
            }
                var config = new MapperConfiguration(cfg => cfg.CreateMap<EditContactViewModel, PhonebookItem>()
                    .ForMember("Key", opt => opt.MapFrom(c => c.Id))
                    .ForMember("Name", opt => opt.MapFrom(c => c.Name))
                    .ForMember("Login", opt => opt.MapFrom(c => c.Email))
                    .ForMember("PhoneNumber", opt => opt.MapFrom(c => c.PhoneNumber))
                    .ForMember("IsAdded", opt => opt.MapFrom(c => c.CheckNull)));
                config.AssertConfigurationIsValid();// to check automapper
                var mapper = new Mapper(config);

                PhonebookItem item = mapper.Map<EditContactViewModel, PhonebookItem>(model);
            var pbitem = PhonebookItem.Find(key);
            if (pbitem == null)
            {
                return NotFound();
            }
                repo.Update(item);
                repo.Save(item);
                return RedirectToAction("GetAll");
        }

        [HttpDelete("{key}")]
        public ActionResult Delete(string key, [FromBody]DeleteContactViewModel model)
        {
            if (key == null)
            {
              return NotFound();
            }
            var config = new MapperConfiguration(cfg => cfg.CreateMap<DeleteContactViewModel, PhonebookItem>()
                .ForMember("Key", opt => opt.MapFrom(c => c.Id))
                .ForMember("Name", opt => opt.MapFrom(c => c.Name))
                .ForMember("Login", opt => opt.MapFrom(c => c.Email))
                .ForMember("PhoneNumber", opt => opt.MapFrom(c => c.PhoneNumber))
                .ForMember("IsAdded", opt => opt.MapFrom(c => c.CheckNull)));
            config.AssertConfigurationIsValid();// to check automapper
                var mapper = new Mapper(config);

                PhonebookItem item = mapper.Map<DeleteContactViewModel, PhonebookItem>(model);
                repo.Delete(key);
                return RedirectToAction("GetAll");
        }
    }
}
