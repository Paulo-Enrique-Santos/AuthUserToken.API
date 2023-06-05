using AuthUserToken.Domain.Model.Entity;
using AuthUserToken.Domain.Model.Request;

namespace AuthUserToken.Domain.Interface.Repository
{
    public interface IUserRepository
    {
        Task<User> RegisterUserAsync(User user);
        Task<User?> GetUserByIdAsync(int idUser);
        Task<User?> GetUserByEmailOrNickNameAsync(string emailOrNickName);
        Task<User?> GetUserByNickNameAsync(string nickName);
        Task<User?> GetUserByEmailAsync(string email);
        Task<User> UpdateUserAsync(User user);
        Task<User> DeleteUserAsync(User user);
    }
}
