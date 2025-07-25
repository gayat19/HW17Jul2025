using FirstAPI.Contexts;
using FirstAPI.Models;

namespace FirstAPI.Repositories
{
    public class EmployeeRepositoryDB : RepositoryDB<int, Employee>
    {
        public EmployeeRepositoryDB(EmployeeManagementContext context):base(context)
        {
           
        }
        public override IEnumerable<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }

        public override Employee GetById(int key)
        {
            var result = _context.Employees.SingleOrDefault(e=>e.Id == key);
            return result;
        }
    }
}
