using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AuthUserToken.Domain.Exceptions
{
    public class InternalServerErrorException : Exception
    {
        public int StatusCode { get; }

        public InternalServerErrorException(string message) : base(message)
        {
            StatusCode = (int)HttpStatusCode.NotFound;
        }
    }
}
