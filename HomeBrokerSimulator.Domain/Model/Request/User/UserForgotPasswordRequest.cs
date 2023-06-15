namespace HomeBrokerSimulator.Domain.Model.Request.User
{
    public class UserForgotPasswordRequest
    {
        public int IdUser { get; set; }
        public string? Password { get; set; }
    }
}
