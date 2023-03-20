using AuthUserToken.Domain.Interface.Repository;
using AuthUserToken.Domain.Interface.Service;
using AuthUserToken.Domain.Model.Entity;
using AuthUserToken.Domain.Model.Request;
using AuthUserToken.Domain.Model.Response;
using AuthUserToken.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AuthUserToken.Domain.Serivce
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResultService<UserResponse>> GetUserByIdAsync(int idUser)
        {
            var user = await _userRepository.GetUserByIdAsync(idUser);

            if (user == null)
                return ResultService.Fail<UserResponse>((int) HttpStatusCode.NotFound, "O Usuário de id " + idUser + " não foi encontrado");

            var response = new UserResponse(user.IdUser, user.Name, user.NickName);

            return ResultService.Ok<UserResponse>((int) HttpStatusCode.OK, response);
        }

        public async Task<ResultService<UserResponse>> LoginUserAsync(UserLoginRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<ResultService<UserResponse>> RegisterUserAsync(UserRegisterRequest request)
        {
            if (request == null)
                return ResultService.Fail<UserResponse>((int) HttpStatusCode.BadRequest, "Os dados do usuario deve ser informado!");

            var user = new User(request.Name, request.NickName, request.Email, request.Password);

            var validateEmail = await _userRepository.GetUserByEmailAsync(request.Email);

            if (validateEmail != null)
                return ResultService.Fail<UserResponse>((int) HttpStatusCode.Conflict, "Esse email já está cadastrado no nosso sistema!");

            var validateNick = await _userRepository.GetUserByNickNameAsync(request.NickName);

            if (validateNick != null)
                return ResultService.Fail<UserResponse>((int) HttpStatusCode.Conflict, "Esse Usuário já está em uso!");

            var register = await _userRepository.RegisterUserAsync(user);

            if (register == null)
                return ResultService.Fail<UserResponse>((int) HttpStatusCode.InternalServerError, "Ocorreu um erro interno");

            var response = new UserResponse(register.IdUser, register.Name, register.NickName);

            return ResultService.Ok<UserResponse>((int) HttpStatusCode.Created, response);
        }

        public Task<ResultService<string>> UpdatePasswordAsync(UserForgotPasswordRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
