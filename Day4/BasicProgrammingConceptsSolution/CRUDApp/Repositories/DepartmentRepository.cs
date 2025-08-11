using CRUDApp.Exceptions;
using CRUDApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDApp.Repositories
{
    public class DepartmentRepository : Repository<int, Department>
    {
        public override Department GetById(int key)
        {
            var department = list.FirstOrDefault(x => x.Id == key);
            if (department == null)
                throw new NoSuchEntityException();
            return department;
        }
    }
}
