using AuthUserToken.Domain.Model.Entity;

namespace AuthUserToken.Domain.Model.Response
{
    public class UserResponse
    {
        public string? Name { get; set; }
        public string? NickName { get; set; }

        public UserResponse(User user)
        {
            Name = user.Name;
            NickName = user.NickName;
        }

        public UserResponse() { }
    }
}
