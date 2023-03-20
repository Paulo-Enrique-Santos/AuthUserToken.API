using System.Net;

namespace AuthUserToken.Domain.Validations
{
    public class ResultService
    {
        public bool IsSuccess { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public static ResultService<T> Fail<T>(int statusCode, string message) => new ResultService<T> { IsSuccess = false, StatusCode = statusCode, Message = message };
        public static ResultService<T> Ok<T>(int statusCode, T data) => new ResultService<T> { IsSuccess = true, StatusCode = statusCode, Data = data };
    }

    public class ResultService<T> : ResultService
    {
        public T Data { get; set; }
    }
}
