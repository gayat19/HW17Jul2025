using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicProgrammingConceptsApp.Exceptions
{
    public class EqualNumberException : Exception
    {
        private string message;
        public EqualNumberException() {
            message = "Numbers are equal";
        }
        public EqualNumberException(string msg)
        {
            message = msg;
        }

        public override string Message => message;
    }
}
