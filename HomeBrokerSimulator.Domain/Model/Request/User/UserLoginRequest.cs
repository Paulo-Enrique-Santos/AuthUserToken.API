namespace HomeBrokerSimulator.Domain.Model.Request.User
{
    public class UserLoginRequest
    {
        public string EmailOrNickName { get; set; }
        public string Password { get; set; }
    }
}
