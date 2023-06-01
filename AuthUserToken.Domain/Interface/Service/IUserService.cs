using AuthUserToken.Domain.Model.Entity;
using AuthUserToken.Domain.Model.Request;
using AuthUserToken.Domain.Model.Response;
using AuthUserToken.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthUserToken.Domain.Interface.Service
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
