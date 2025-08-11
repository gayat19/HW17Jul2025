using FirstAPI.Contexts;
using FirstAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Repositories
{
    public class DepartmentStatusRepository : RepositoryDB<int, DepartmnetStatusMaster>
    {
        public DepartmentStatusRepository(EmployeeManagementContext context):base(context)
        {
            
        }
        public async override Task<IEnumerable<DepartmnetStatusMaster>> GetAll()
        {
            return _context.DepartmnetStatusMasters;
        }

        public async override Task<DepartmnetStatusMaster> GetById(int key)
        {
            var result = await _context.DepartmnetStatusMasters.SingleOrDefaultAsync(dm => dm.Id == key);
            return result;
        }
    }
}
