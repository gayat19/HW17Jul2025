using FirstAPI.Contexts;
using FirstAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Repositories
{
    public class EmployeeStatusRepository : RepositoryDB<int, EmployeeStatusMaster>
    {
        public EmployeeStatusRepository(EmployeeManagementContext context) : base(context)
        { }

        public async override Task<IEnumerable<EmployeeStatusMaster>> GetAll()
        {
            return _context.EmployeeStatusMaster;
        }

        public async override Task<EmployeeStatusMaster> GetById(int key)
        {
            var result = await _context.EmployeeStatusMaster.SingleOrDefaultAsync(x => x.Id == key);
            return result;
        }
    }
}
