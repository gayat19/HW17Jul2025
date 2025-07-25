using FirstAPI.Contexts;
using FirstAPI.Models;

namespace FirstAPI.Repositories
{
    public class DepartmentRepositoryDb : RepositoryDB<int, Department>
    {
        public DepartmentRepositoryDb(EmployeeManagementContext context):base(context) 
        {
            
        }
        public override IEnumerable<Department> GetAll()
        {
            return _context.Departments;
        }

        public override Department GetById(int key)
        {
            return _context.Departments.SingleOrDefault(d => d.Id == key);
        }
    }
}
