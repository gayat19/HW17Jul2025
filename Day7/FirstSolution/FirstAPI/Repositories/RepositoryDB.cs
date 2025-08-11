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
        public async Task<T> Add(T entity)
        {
            _context.ChangeTracker.Clear();
            _context.Add(entity);//Adds the entry to the current collection. Marks teh status of teh entry to added
            await _context.SaveChangesAsync();//Creates the insert query with the new value and executes it.
            return entity;//new object withteh identity will be provided
        }

        public async Task<T> Delete(K key)
        {
            _context.ChangeTracker.Clear();
            var obj = await GetById(key);//Gets teh object withteh ID
            _context.Remove(obj);//Identifies teh object within teh colelction, marks teh status to deleted
            await _context.SaveChangesAsync();//Generates the delete queryby default cascading delete
            return obj;//returns the deleted object
        }

        public abstract Task<IEnumerable<T>> GetAll();

        public abstract Task<T> GetById(K key);
        

        public async Task<T> Update(K key, T entity)
        {
            _context.ChangeTracker.Clear();
            var obj= await GetById(key);
            _context.Entry<T>(obj).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
