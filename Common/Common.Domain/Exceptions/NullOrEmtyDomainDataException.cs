using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Exceptions
{
    public class NullOrEmtyDomainDataException : BaseDomainException
    {
        public NullOrEmtyDomainDataException()
        {

        }
        public NullOrEmtyDomainDataException(string message) : base(message)
        {

        }
        public static void CheckString(string value, string nameOfField)
        {
            if (string.IsNullOrEmpty(value))
                throw new NullOrEmtyDomainDataException($"{nameOfField} Is Null Or Empty");
        }
    }

}
