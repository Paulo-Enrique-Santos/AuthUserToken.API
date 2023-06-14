using System.Net;

namespace HomeBrokerSimulator.Domain.Exceptions
{
    public class ConflictException : Exception
    {
        public int StatusCode { get; }

        public ConflictException(string message) : base(message)
        {
            StatusCode = (int)HttpStatusCode.Conflict;
        }
    }
}
