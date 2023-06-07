using HomeBrokerSimulator.Domain.Interface.Repository;
using HomeBrokerSimulator.Domain.Model.Entity;
using HomeBrokerSimulator.Domain.Model.Request;
using HomeBrokerSimulator.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBrokerSimulator.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
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

        public async Task<User?> GetUserByEmailOrNickNameAsync(string emailOrNickName)
        {
            return await _appDbContext.User.FirstOrDefaultAsync(x => x.Email.Equals(emailOrNickName) || x.NickName.Equals(emailOrNickName));
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
