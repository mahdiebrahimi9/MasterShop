using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Domain.Shared.Exceptions
{
    public class NullOrEmptyDomainDataException : BaseDomainException
    {
        public NullOrEmptyDomainDataException()
        {

        }

        public NullOrEmptyDomainDataException(string message) : base(message)
        {

        }

        public static void CheckString(string value, string nameOfFiled)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new NullOrEmptyDomainDataException($"{nameOfFiled} is null or empty");
        }
    }
}
