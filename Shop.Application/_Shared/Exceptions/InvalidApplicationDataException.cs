using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application._Shared.Exceptions
{
    public class InvalidApplicationDataException : BaseApplicationException
    {
        public InvalidApplicationDataException()
        {

        }

        public InvalidApplicationDataException(string message) : base(message)
        {

        }
    }
}
