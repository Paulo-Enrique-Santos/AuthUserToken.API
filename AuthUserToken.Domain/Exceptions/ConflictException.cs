﻿using System.Net;

namespace AuthUserToken.Domain.Exceptions
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
