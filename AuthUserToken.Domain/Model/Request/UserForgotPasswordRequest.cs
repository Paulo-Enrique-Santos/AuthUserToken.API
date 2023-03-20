namespace AuthUserToken.Domain.Model.Request
{
    public class UserForgotPasswordRequest
    {
        public int IdUser { get; set; }
        public string Password { get; set; }
    }
}
