using FirstAPI.Contexts;
using FirstAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Repositories
{
    public class EmployeeRepositoryDB : RepositoryDB<int, Employee>
    {
        public EmployeeRepositoryDB(EmployeeManagementContext context):base(context)
        {
           
        }
        public async override Task<IEnumerable<Employee>> GetAll()
        {
            return await _context.Employees.ToListAsync();
        }

        public async override Task<Employee> GetById(int key)
        {
            var result = await _context.Employees.SingleOrDefaultAsync(e=>e.Id == key);
            return result;
        }
    }
}
