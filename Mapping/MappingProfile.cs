using AutoMapper;
using PhonesBook.ApiModels;
using PhonesBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhonesBook.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<AddContactDTO, Contact>();
            CreateMap<Contact, AddContactDTO>();
            CreateMap<EditContactDTO, Contact>();
            CreateMap<Contact, EditContactDTO>();
            CreateMap<DeleteContactDTO, Contact>();
            CreateMap<Contact, DeleteContactDTO>();
        }
    }
}
