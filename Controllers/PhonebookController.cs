using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhonesBook.ApiModels;
using AutoMapper;
using PhonesBook.Models;
using PhonesBook.Service;

namespace PhonesBook.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PhonebookController : Controller
    {
        private readonly IMapper _mapper;
        
        private IGenericRepository<Contact> сontactRepository;
        public PhonebookController(IGenericRepository<Contact> сontactRepository, IMapper mapper)
        {
            this.сontactRepository = сontactRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<Contact> GetAll()
        {
            return сontactRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Contact GetById(int id)
        {
            return сontactRepository.GetById(id);
        }

        [HttpPost]
        public ActionResult Add(AddContactDTO model)
        {
            if (ModelState.IsValid)
            {
                Contact item = _mapper.Map<AddContactDTO, Contact>(model);
                сontactRepository.Insert(item);
            }
            return Ok(model);
        }

        [HttpPut("{id}")]
        public ActionResult Edit(int Id, EditContactDTO model)
        {
            if (Id == 0)
            {
                return NotFound();
            }
            if (Id !=  model.Id)
            {
                return BadRequest("Ids did not match");
            }
            var findContact = сontactRepository.GetById(Id);
            if (findContact == null)
            {
                return NotFound();
            }
            _mapper.Map<EditContactDTO, Contact>(model, findContact);
            сontactRepository.Update(findContact);
            return Ok(findContact);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id, DeleteContactDTO model)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var findContact = сontactRepository.GetById(id);
            _mapper.Map<DeleteContactDTO, Contact>(model);
            сontactRepository.Delete(findContact);
            return Ok();
        }
    }
}
