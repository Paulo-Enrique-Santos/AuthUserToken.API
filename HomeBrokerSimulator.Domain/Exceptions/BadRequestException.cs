using System.Net;

namespace HomeBrokerSimulator.Domain.Exceptions
{
    public class BadRequestException : Exception
    {
        public int StatusCode { get; }

        public BadRequestException(string message) : base(message)
        {
            StatusCode = (int)HttpStatusCode.BadRequest;
        }
    }
}
