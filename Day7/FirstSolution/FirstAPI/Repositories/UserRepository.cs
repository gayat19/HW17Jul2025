using FirstAPI.Contexts;
using FirstAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Repositories
{
    public class UserRepository : RepositoryDB<string, User>
    {
        public UserRepository(EmployeeManagementContext context):base(context)
        {
            
        }
        public async override Task<IEnumerable<User>> GetAll()
        {
            return _context.Users;
        }

        public async override Task<User> GetById(string key)
        {
            var result = await _context.Users.SingleOrDefaultAsync(u => u.Username == key);
            return result;
        }
    }
}
