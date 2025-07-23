using CRUDApp.Exceptions;
using CRUDApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDApp.Repositories
{
    public abstract class Repository<K, T> : IRepository<K, T> where T : class
    {
        protected List<T> list = new List<T>();

        public T Add(T entity)
        {
            list.Add(entity);
            return entity;
        }

        public T Delete(K key)
        {
            var item = GetById(key);
            if (item != null)
            {
                list.Remove(item);
                return item;
            }
            throw new NoSuchEntityException();
        }

        public IEnumerable<T> GetAll()
        {
            if(list == null)
                throw new NoEntriessInCollectionException();
        }

        public abstract T GetById(K key);
 

        public T Update(K key, T entity)
        {
            var item = GetById(key);
            if (item != null)
            {
                list.Remove(item);
                list.Add(entity);
                return item;
            }
            throw new NoSuchEntityException();
        }
    }
}
