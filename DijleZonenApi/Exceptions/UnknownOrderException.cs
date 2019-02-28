using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DijleZonenApi.Exceptions
{
    public class UnknownOrderException : Exception
    {
        public UnknownOrderException()
        {

        }

        public UnknownOrderException(string message)
       : base(message)
        {
        }

        public UnknownOrderException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
