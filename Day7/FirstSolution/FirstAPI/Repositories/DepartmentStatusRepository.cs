using FirstAPI.Contexts;
using FirstAPI.Models;

namespace FirstAPI.Repositories
{
    public class DepartmentStatusRepository : RepositoryDB<int, DepartmnetStatusMaster>
    {
        public DepartmentStatusRepository(EmployeeManagementContext context):base(context)
        {
            
        }
        public override IEnumerable<DepartmnetStatusMaster> GetAll()
        {
            return _context.DepartmnetStatusMasters;
        }

        public override DepartmnetStatusMaster GetById(int key)
        {
            var result = _context.DepartmnetStatusMasters.SingleOrDefault(dm=>dm.Id == key);
            return result;
        }
    }
}
