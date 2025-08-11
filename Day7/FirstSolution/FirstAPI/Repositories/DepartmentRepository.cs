using FirstAPI.Exceptions;
using FirstAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAPI.Repositories
{
    public class DepartmentRepository : Repository<int, Department>
    {
        public async override Task<Department> GetById(int key)
        {
            var department = list.FirstOrDefault(x => x.Id == key);
            if (department == null)
                throw new NoSuchEntityException();
            return department;
        }
    }
}
