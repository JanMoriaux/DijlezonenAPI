using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DijleZonenApi.Exceptions
{
    public class UnknownCustomerException : Exception
    {
        public UnknownCustomerException()
        {
               
        }

        public UnknownCustomerException(string message)
       : base(message)
        {
        }

        public UnknownCustomerException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
