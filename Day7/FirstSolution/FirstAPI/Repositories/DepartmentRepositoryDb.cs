using FirstAPI.Contexts;
using FirstAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Repositories
{
    public class DepartmentRepositoryDb : RepositoryDB<int, Department>
    {
        public DepartmentRepositoryDb(EmployeeManagementContext context):base(context) 
        {
            
        }
        public async override Task<IEnumerable<Department>> GetAll()
        {
            return _context.Departments;
        }

        public async override Task<Department> GetById(int key)
        {
            return await _context.Departments.SingleOrDefaultAsync(d => d.Id == key);
        }
    }
}
