using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhonesBook.ApiModels
{
    public interface IRepository
    {
        IEnumerable<PhonebookItem> GetAll();
        IEnumerable<PhonebookItem> GetById(int id);
        void Add(PhonebookItem item);
        void Update(PhonebookItem item);
        void Save(PhonebookItem item);
        void Delete(string key);
    }
}
