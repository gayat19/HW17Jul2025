using FirstAPI.Contexts;
using FirstAPI.Models;

namespace FirstAPI.Repositories
{
    public class EmployeeStatusRepository : RepositoryDB<int, EmployeeStatusMaster>
    {
        public EmployeeStatusRepository(EmployeeManagementContext context) : base(context)
        { }

        public override IEnumerable<EmployeeStatusMaster> GetAll()
        {
            return _context.EmployeeStatusMaster;
        }

        public override EmployeeStatusMaster GetById(int key)
        {
            var result = _context.EmployeeStatusMaster.SingleOrDefault(x => x.Id == key);
            return result;
        }
    }
}
