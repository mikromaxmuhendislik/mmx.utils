using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace V7.BaseApplication.Utilies.Exceptions
{
    public class InvalidTaxNumberException : Exception
    {
        public InvalidTaxNumberException()
        {
        }

        public InvalidTaxNumberException(string message) : base(message)
        {
        }

        public InvalidTaxNumberException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidTaxNumberException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
