using HomeBrokerSimulator.Domain.Model.Entity;

namespace HomeBrokerSimulator.Domain.Model.Response
{
    public class UserLoginResponse
    {
        public string? Name { get; set; }
        public string? NickName { get; set; }
        public dynamic Token { get; set; }

        public UserLoginResponse(User user, dynamic token)
        {
            Name = user.Name;
            NickName = user.NickName;
            Token = token;
        }

        public UserLoginResponse() { }
    }
}
