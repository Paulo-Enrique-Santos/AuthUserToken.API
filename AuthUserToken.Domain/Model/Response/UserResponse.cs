namespace AuthUserToken.Domain.Model.Response
{
    public class UserResponse
    {
        public int IdUser { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }

        public UserResponse(int idUser, string name, string nickName)
        {
            IdUser = idUser;
            Name = name;
            NickName = nickName;
        }

        public UserResponse() { }
    }
}
