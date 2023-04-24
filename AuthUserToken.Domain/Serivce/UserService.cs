using AuthUserToken.Domain.Interface.Authentication;
using AuthUserToken.Domain.Interface.Repository;
using AuthUserToken.Domain.Interface.Service;
using AuthUserToken.Domain.Model.Entity;
using AuthUserToken.Domain.Model.Request;
using AuthUserToken.Domain.Model.Response;
using AuthUserToken.Domain.Validations;
using System.Net;

namespace AuthUserToken.Domain.Serivce
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenGenerator _tokenGenerator;
        public UserService(IUserRepository userRepository, ITokenGenerator tokenGenerator)
        {
            _userRepository = userRepository;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<ResultService<string>> DeleteUserByIdAsync(int idUser)
        {
            var user = await _userRepository.GetUserByIdAsync(idUser);

            if (user == null)
                return ResultService.Fail<string>((int) HttpStatusCode.NotFound, "Usuário não encontrado");

            var response = await _userRepository.DeleteUserAsync(user);

            if (response == null)
                return ResultService.Fail<string>((int) HttpStatusCode.InternalServerError, "Ocorreu um erro interno");

            return ResultService.Ok<string>((int) HttpStatusCode.OK, "Usuário deletado com sucesso!");
        }

        public async Task<ResultService<UserResponse>> GetUserByIdAsync(int idUser)
        {
            var user = await _userRepository.GetUserByIdAsync(idUser);

            if (user == null)
                return ResultService.Fail<UserResponse>((int) HttpStatusCode.NotFound, "Usuário não encontrado");

            var response = new UserResponse(user.IdUser, user.Name, user.NickName);

            return ResultService.Ok<UserResponse>((int) HttpStatusCode.OK, response);
        }

        public async Task<ResultService<UserLoginResponse>> LoginUserAsync(UserLoginRequest request)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email);

            if (user == null)
                return ResultService.Fail<UserLoginResponse>((int)HttpStatusCode.NotFound, "Email incorreto!");

            if (!user.Password.Equals(request.Password))
                return ResultService.Fail<UserLoginResponse>((int)HttpStatusCode.BadRequest, "Senha incorreta!");

            var token = _tokenGenerator.TokenGenerator(user);

            var response = new UserLoginResponse(user.IdUser, user.Name, user.NickName, token);

            return ResultService.Ok<UserLoginResponse>((int)HttpStatusCode.OK, response);
        }

        public async Task<ResultService<UserResponse>> RegisterUserAsync(UserRegisterRequest request)
        {
            if (request == null)
                return ResultService.Fail<UserResponse>((int) HttpStatusCode.BadRequest, "Os dados do usuario devem ser informados!");

            var user = new User(request.Name, request.NickName, request.Email, request.Password);

            var validateEmail = await _userRepository.GetUserByEmailAsync(request.Email);

            if (validateEmail != null)
                return ResultService.Fail<UserResponse>((int) HttpStatusCode.Conflict, "Esse email já está em uso!");

            var validateNick = await _userRepository.GetUserByNickNameAsync(request.NickName);

            if (validateNick != null)
                return ResultService.Fail<UserResponse>((int) HttpStatusCode.Conflict, "Esse nickname já está em uso!");

            var register = await _userRepository.RegisterUserAsync(user);

            if (register == null)
                return ResultService.Fail<UserResponse>((int) HttpStatusCode.InternalServerError, "Ocorreu um erro interno");

            var response = new UserResponse(register.IdUser, register.Name, register.NickName);

            return ResultService.Ok<UserResponse>((int) HttpStatusCode.Created, response);
        }

        public async Task<ResultService<string>> UpdatePasswordAsync(UserForgotPasswordRequest request)
        {
            if (request == null)
                return ResultService.Fail<string>((int) HttpStatusCode.BadRequest, "Os dados do usuario devem ser informados!");

            var user = await _userRepository.GetUserByIdAsync(request.IdUser);

            if (user == null)
                return ResultService.Fail<string>((int) HttpStatusCode.NotFound, "Usuário não encontrado");

            user.Password = request.Password!;

            var response = await _userRepository.UpdateUserAsync(user);

            if (response == null)
                return ResultService.Fail<string>((int) HttpStatusCode.InternalServerError, "Ocorreu um erro interno");

            return ResultService.Ok<string>((int) HttpStatusCode.OK, "Senha alterada com sucesso!");
        }
    }
}
