using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAPI.Interfaces
{
    public interface IRepository <K,T> where T : class
    {
        public Task<T> Add(T entity);
        public Task<T> Update(K key,T entity);
        public Task<T> Delete(K key);
        public Task<T> GetById(K key);
        public Task<IEnumerable<T>> GetAll();

    }
}
