using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhonesBook.ApiModels
{
    public interface IPhonebookRepository
    {
        IEnumerable<PhonebookItem> GetAll();
        IEnumerable<PhonebookItem> GetById(int id);
        void Create(string key);
        void Update(PhonebookItem item);
        void Save();
        void Delete(string key);
    }
}
