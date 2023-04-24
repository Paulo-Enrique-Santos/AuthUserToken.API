using AuthUserToken.Domain.Interface.Repository;
using AuthUserToken.Domain.Model.Entity;
using AuthUserToken.Domain.Model.Request;
using AuthUserToken.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthUserToken.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<User?> LoginUserAsync(UserLoginRequest userLoginRequest)
        {
            return await _appDbContext.User.FirstOrDefaultAsync(x => x.Email.Equals(userLoginRequest.Email) && x.Password.Equals(userLoginRequest.Password));
        }

        public async Task<User> RegisterUserAsync(User user)
        {
            _appDbContext.User.Add(user);
            await _appDbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User?> GetUserByIdAsync(int idUser)
        {
            return await _appDbContext.User.FirstOrDefaultAsync(x => x.IdUser == idUser);
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            _appDbContext.User.Update(user);
            await _appDbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _appDbContext.User.FirstOrDefaultAsync(x => x.Email.Equals(email));
        }

        public async Task<User?> GetUserByNickNameAsync(string nickName)
        {
            return await _appDbContext.User.FirstOrDefaultAsync(x => x.NickName.Equals(nickName));
        }

        public async Task<User> DeleteUserAsync(User user)
        {
            _appDbContext.User.Remove(user);
            await _appDbContext.SaveChangesAsync();
            return user;
        }
    }
}
