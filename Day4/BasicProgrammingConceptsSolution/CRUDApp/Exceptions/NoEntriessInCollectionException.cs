using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDApp.Exceptions
{
    public class NoEntriessInCollectionException : Exception
    {
        private string _message;
        public NoEntriessInCollectionException()
        {
            _message = "Collection is empty";
        }
        public override string Message => _message;
    }
}
