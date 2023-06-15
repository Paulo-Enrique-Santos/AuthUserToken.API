<<<<<<< HEAD
﻿using HomeBrokerSimulator.Domain.Model.Entity;
using HomeBrokerSimulator.Domain.Model.Request;

namespace HomeBrokerSimulator.Infrastructure.Interface.Repository
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
=======
﻿using HomeBrokerSimulator.Domain.Model.Entity;
using HomeBrokerSimulator.Domain.Model.Request;

namespace HomeBrokerSimulator.Infrastructure.Interface.Repository
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
>>>>>>> 8c1722fb7e54a0ab0ffe4cbc56e972baaecbe9d5
