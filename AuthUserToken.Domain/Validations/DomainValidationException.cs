using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Web.Http;

namespace AuthUserToken.Domain.Validations
{
    public class DomainValidationException : Exception
    {

        public DomainValidationException(string error) : base(error) { }

        public static void When(bool hasError, string message)
        {
            if (hasError)
                throw new DomainValidationException(message);
        }
    }
}
