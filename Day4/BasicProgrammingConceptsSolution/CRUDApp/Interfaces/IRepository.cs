using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDApp.Interfaces
{
    public interface IRepository <K,T> where T : class
    {
        public T Add(T entity);
        public T Update(K key,T entity);
        public T Delete(K key);
        public T GetById(K key);
        public IEnumerable<T> GetAll();

    }
}
