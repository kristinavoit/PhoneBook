using PhonesBook.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhonesBook.Service
{
    public class ContactService : IGenericRepository<PhonebookItem>
    {
        List<PhonebookItem> _phonebookItem = new List<PhonebookItem>();
        public IEnumerable<PhonebookItem> GetAll()
        {
            return _phonebookItem;
        }

        public PhonebookItem GetById(Guid id)
        {
            return _phonebookItem.Where(x => x.ContactId == id).SingleOrDefault();
        }

        public bool Update(PhonebookItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = _phonebookItem.FindIndex(p => p.ContactId == item.ContactId);
            if (index == -1)
            {
                return false;
            }
            _phonebookItem.RemoveAt(index);
            _phonebookItem.Add(item);
            return true;
            //_phonebookItem[item.ContactId] = item;
            //item.ModifiedOn = DateTime.Now;
            //_phonebookItem.Set<T>().Attach(item);
            //_phonebookItem.Entry(item).State = EntityState.Modified;
        }
        public void Insert(PhonebookItem item)
        {
            _phonebookItem.Add(item);
        }

        public void Delete(Guid id)
        {
            _phonebookItem.RemoveAll(x => x.ContactId == id);
        }
    }
}
