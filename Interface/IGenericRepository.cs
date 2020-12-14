using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhonesBook.ApiModels
{
    public interface IGenericRepository<T> where T: class
    {
        IEnumerable<T> GetAll();
        T GetById(Guid id);
        bool Update(T item);
        void Insert(T item);
        void Delete(Guid id);
    }
}
