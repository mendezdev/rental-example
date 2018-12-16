using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptions
{
    public class RentalRequiredFieldException : Exception
    {
        public RentalRequiredFieldException() { }

        public RentalRequiredFieldException(string message) : base(message) { }

        public RentalRequiredFieldException(string message, Exception inner) : base(message, inner) { }
    }
}
