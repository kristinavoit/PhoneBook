using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhonesBook.ApiModels
{
    public class phonebookItem: IRepository
    {
        private static ConcurrentDictionary<string, PhonebookItem> _phonebooks =
              new ConcurrentDictionary<string, PhonebookItem>();
        IEnumerable<PhonebookItem> IRepository.GetAll()
        {
            return _phonebooks.Values;
        }

        public IEnumerable<PhonebookItem> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(PhonebookItem item)
        {
            _phonebooks[item.Key] = item;
        }

        public void Save(PhonebookItem item)
        {
            _phonebooks[item.Key] = item;
        }

        public void Delete(string key)
        {
            throw new NotImplementedException();
        }
        public void Add(PhonebookItem item)
        {
            item.Key = Guid.NewGuid().ToString();
            _phonebooks[item.Key] = item;
        }
    }
}
