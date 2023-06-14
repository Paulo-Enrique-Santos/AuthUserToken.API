namespace HomeBrokerSimulator.Domain.Model.Request
{
    public class UserLoginRequest
    {
        public string EmailOrNickName { get; set; }
        public string Password { get; set; }
    }
}
