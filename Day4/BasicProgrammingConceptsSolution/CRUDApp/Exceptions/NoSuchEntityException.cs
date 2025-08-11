using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDApp.Exceptions
{
    internal class NoSuchEntityException : Exception
    {
        private string _message;
        public NoSuchEntityException()
        {
            _message = "Entity with the given Id not present";
        }
        public override string Message => _message;
    }
}
