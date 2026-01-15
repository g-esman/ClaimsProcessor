using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsProcessor.Domain.Exceptions
{
    public class ClaimApplicationException : Exception
    {
        public ClaimApplicationException(string message) : base(message) { }
    }
}
