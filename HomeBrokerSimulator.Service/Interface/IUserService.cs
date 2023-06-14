using HomeBrokerSimulator.Domain.Model.Entity;
using HomeBrokerSimulator.Domain.Model.Request;
using HomeBrokerSimulator.Domain.Model.Response;
using HomeBrokerSimulator.Domain.Validations;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBrokerSimulator.Service.Interface
{
    public interface IUserService
    {
        Task<UserResponse> RegisterUserAsync(UserRegisterRequest request);
        Task<UserLoginResponse> LoginUserAsync(UserLoginRequest request);
        Task<byte[]> UpdateImageAsync(string idUser, IFormFile image);
        Task<User> GetUserByIdAsync(string idUser);
        Task<GenericResponse> DeleteUserByIdAsync(string idUser);
    }
}
