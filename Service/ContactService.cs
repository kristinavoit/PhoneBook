using PhonesBook.ApiModels;
using PhonesBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhonesBook.Service
{
    public class ContactService : IGenericRepository<Contact>
    {
        private readonly RepositoryContext _ctx;

        public ContactService(RepositoryContext ctx)
        {
            _ctx = ctx;
        }
        public IEnumerable<Contact> GetAll()
        {
            return _ctx.Set<Contact>().ToList();
        }

        public Contact GetById(int id)
        {
            return _ctx.Set<Contact>().Find(id);
        }

        public void Update(Contact item)
        {
            _ctx.Set<Contact>().Update(item);
            _ctx.SaveChanges();
        }
        public void Insert(Contact item)
        {
            _ctx.Set<Contact>().Add(item);
            _ctx.SaveChanges();
        }

        public void Delete(Contact item)
        {
            _ctx.Set<Contact>().Remove(item);
            _ctx.SaveChanges();
        }
    }
}
