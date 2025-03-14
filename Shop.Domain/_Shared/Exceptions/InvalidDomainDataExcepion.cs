using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Domain.Shared.Exceptions;

namespace Shop.Domain._Shared.Exceptions
{
    public class InvalidDomainDataExcepion : BaseDomainException
    {
        public InvalidDomainDataExcepion()
        {

        }

        public InvalidDomainDataExcepion(string message) : base(message)
        {

        }
    }
}
