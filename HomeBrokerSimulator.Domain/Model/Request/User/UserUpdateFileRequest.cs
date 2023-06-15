using Microsoft.AspNetCore.Http;

namespace HomeBrokerSimulator.Domain.Model.Request.User
{
    public class UserUpdateFileRequest
    {
        public IFormFile Image { get; set; }
    }
}
