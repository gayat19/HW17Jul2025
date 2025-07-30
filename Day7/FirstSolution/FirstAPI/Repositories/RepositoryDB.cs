using FirstAPI.Contexts;
using FirstAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Repositories
{
    public abstract class RepositoryDB<K, T> : IRepository<K, T> where T : class
    {
        protected readonly EmployeeManagementContext _context;

        public RepositoryDB(EmployeeManagementContext context)
        {
            _context = context;
        }
        public T Add(T entity)
        {
            _context.ChangeTracker.Clear();
            _context.Add(entity);//Adds the entry to the current collection. Marks teh status of teh entry to added
            _context.SaveChanges();//Creates the insert query with the new value and executes it.
            return entity;//new object withteh identity will be provided
        }

        public T Delete(K key)
        {
            _context.ChangeTracker.Clear();
            var obj = GetById(key);//Gets teh object withteh ID
            _context.Remove(obj);//Identifies teh object within teh colelction, marks teh status to deleted
            _context.SaveChanges();//Generates the delete queryby default cascading delete
            return obj;//returns the deleted object
        }

        public abstract IEnumerable<T> GetAll();

        public abstract T GetById(K key);
        

        public T Update(K key, T entity)
        {
            _context.ChangeTracker.Clear();
            var obj= GetById(key);
            _context.Entry<T>(obj).CurrentValues.SetValues(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
