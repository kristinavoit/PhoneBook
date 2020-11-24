using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhonesBook.ApiModels
{
    public class PhonebookRepository: IPhonebookRepository
    {
        private static ConcurrentDictionary<string, PhonebookItem> _phonebooks =
              new ConcurrentDictionary<string, PhonebookItem>();
        IEnumerable<PhonebookItem> IPhonebookRepository.GetAll()
        {
            return _phonebooks.Values;
        }

        public IEnumerable<PhonebookItem> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Create(string key)
        {
            throw new NotImplementedException();
        }

        public void Update(PhonebookItem item)
        {
            _phonebooks[item.Key] = item;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Delete(string key)
        {
            throw new NotImplementedException();
        }
    }
}
