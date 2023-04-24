namespace AuthUserToken.Domain.Model.Response
{
    public class UserLoginResponse
    {
        public int IdUser { get; set; }
        public string? Name { get; set; }
        public string? NickName { get; set; }
        public dynamic Token { get; set; }

        public UserLoginResponse(int idUser, string name, string nickName, dynamic token)
        {
            IdUser = idUser;
            Name = name;
            NickName = nickName;
            Token = token;
        }

        public UserLoginResponse() { }
    }
}
