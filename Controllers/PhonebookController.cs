using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhonesBook.ApiModels;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhonesBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhonebookController : Controller
    {
        private IGenericRepository<PhonebookItem> _repository;
        public PhonebookController(IGenericRepository<PhonebookItem> phonebookItem)
        {
            this._repository = phonebookItem;
        }
        public IGenericRepository<PhonebookItem> PhonebookItem { get; set; }

        public IEnumerable<PhonebookItem> GetAll()
        {
            return PhonebookItem.GetAll();
        }

        [HttpPost]
        public ActionResult Add([FromBody]AddContactDTO model)
        {
            if (ModelState.IsValid){
                var config = new MapperConfiguration(cfg => cfg.CreateMap<AddContactDTO, PhonebookItem>()
                    .ForMember("Key", opt => opt.MapFrom(c => c.Id))
                    .ForMember("Name", opt => opt.MapFrom(c => c.Name))
                    .ForMember("Login", opt => opt.Ignore())
                    .ForMember("PhoneNumber", opt => opt.MapFrom(c => c.PhoneNumber))
                    .ForMember("IsAdded", opt => opt.MapFrom(c => c.CheckNull)));
                config.AssertConfigurationIsValid();// to check automapper
                var mapper = new Mapper(config);

                PhonebookItem item = mapper.Map<AddContactDTO, PhonebookItem>(model);
                _repository.Insert(item);
                return Ok(item);

            }
            return View(model);
        }

        [HttpPut("{id}")]
        [Route("{id:guid}")]
        public ActionResult Edit(string id, [FromBody]EditContactDTO model)
        {
            if (id == null )
            {
                return NotFound();
            }
                var config = new MapperConfiguration(cfg => cfg.CreateMap<EditContactDTO, PhonebookItem>()
                    .ForMember("Key", opt => opt.MapFrom(c => c.Id))
                    .ForMember("Name", opt => opt.MapFrom(c => c.Name))
                    .ForMember("Login", opt => opt.MapFrom(c => c.Email))
                    .ForMember("PhoneNumber", opt => opt.MapFrom(c => c.PhoneNumber))
                    .ForMember("IsAdded", opt => opt.MapFrom(c => c.CheckNull)));
                config.AssertConfigurationIsValid();// to check automapper
                var mapper = new Mapper(config);

                PhonebookItem item = mapper.Map<EditContactDTO, PhonebookItem>(model);
                _repository.Update(item);
            //if (pbitem == null)
            //{
            //    return NotFound();
            //}
                _repository.Insert(item);
                return Ok(item);
        }

        [HttpDelete("{key}")]
        [Route("{id:guid}")]
        public ActionResult Delete(Guid id, [FromBody]DeleteContactDTO model)
        {
            if (id == null)
            {
              return NotFound();
            }
            var config = new MapperConfiguration(cfg => cfg.CreateMap<DeleteContactDTO, PhonebookItem>()
                .ForMember("Key", opt => opt.MapFrom(c => c.Id))
                .ForMember("Name", opt => opt.MapFrom(c => c.Name))
                .ForMember("Login", opt => opt.MapFrom(c => c.Email))
                .ForMember("PhoneNumber", opt => opt.MapFrom(c => c.PhoneNumber))
                .ForMember("IsAdded", opt => opt.MapFrom(c => c.CheckNull)));
            config.AssertConfigurationIsValid();// to check automapper
                var mapper = new Mapper(config);

                PhonebookItem item = mapper.Map<DeleteContactDTO, PhonebookItem>(model);
                _repository.Delete(id);
                return Ok(item);
        }
    }
}
