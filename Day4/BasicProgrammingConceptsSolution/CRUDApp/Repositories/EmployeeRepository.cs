using CRUDApp.Exceptions;
using CRUDApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDApp.Repositories
{
    public class EmployeeRepository : Repository<int, Employee>
    {
        public override Employee GetById(int key)
        {
            var item= list.FirstOrDefault(x => x.Id == key);
            if (item == null)
                throw new NoSuchEntityException();
            return item;
        }
    }
}
