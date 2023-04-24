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
        Task<ResultService<UserResponse>> RegisterUserAsync(UserRegisterRequest request);
        Task<ResultService<UserLoginResponse>> LoginUserAsync(UserLoginRequest request);
        Task<ResultService<string>> UpdatePasswordAsync(UserForgotPasswordRequest request);
        Task<ResultService<UserResponse>> GetUserByIdAsync(int idUser);
        Task<ResultService<string>> DeleteUserByIdAsync(int idUser);
    }
}
