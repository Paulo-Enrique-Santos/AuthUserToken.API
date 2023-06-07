using HomeBrokerSimulator.Domain.Model.Entity;
using HomeBrokerSimulator.Domain.Model.Request;
using HomeBrokerSimulator.Domain.Model.Response;
using HomeBrokerSimulator.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBrokerSimulator.Domain.Interface.Service
{
    public interface IUserService
    {
        Task<UserResponse> RegisterUserAsync(UserRegisterRequest request);
        Task<UserLoginResponse> LoginUserAsync(UserLoginRequest request);
        Task<GenericResponse> UpdatePasswordAsync(string idUser, string password);
        Task<User> GetUserByIdAsync(string idUser);
        Task<GenericResponse> DeleteUserByIdAsync(string idUser);
    }
}
