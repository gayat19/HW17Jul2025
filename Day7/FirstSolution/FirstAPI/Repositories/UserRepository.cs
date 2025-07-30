using FirstAPI.Contexts;
using FirstAPI.Models;

namespace FirstAPI.Repositories
{
    public class UserRepository : RepositoryDB<string, User>
    {
        public UserRepository(EmployeeManagementContext context):base(context)
        {
            
        }
        public override IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public override User GetById(string key)
        {
            var result = _context.Users.SingleOrDefault(u=>u.Username == key);
            return result;
        }
    }
}
