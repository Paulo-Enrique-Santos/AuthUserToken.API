using AuthUserToken.Domain.Exceptions;
using AuthUserToken.Domain.Interface.Authentication;
using AuthUserToken.Domain.Interface.Repository;
using AuthUserToken.Domain.Interface.Service;
using AuthUserToken.Domain.Model.Entity;
using AuthUserToken.Domain.Model.Request;
using AuthUserToken.Domain.Model.Response;
using AuthUserToken.Domain.Validations;
using Newtonsoft.Json.Linq;
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

        public async Task<GenericResponse> DeleteUserByIdAsync(string idUser)
        {
            int.TryParse(idUser, out int id);

            var user = await _userRepository.GetUserByIdAsync(id);

            if (user == null)
                throw new NotFoundException("Usuário não encontrado!");

            var response = await _userRepository.DeleteUserAsync(user);

            if (response == null)
                throw new InternalServerErrorException("Problemas para deletar usuário, tente novamente!");

            return new GenericResponse("Conta excluida com sucesso!");
        }

        public async Task<User> GetUserByIdAsync(string idUser)
        {
            int.TryParse(idUser, out int id);

            var response = await _userRepository.GetUserByIdAsync(id);

            if (response == null)
                throw new NotFoundException("Usuário não encontrado!");

            return response;
        }

        public async Task<UserLoginResponse> LoginUserAsync(UserLoginRequest request)
        {
            var user = await _userRepository.GetUserByEmailOrNickNameAsync(request.EmailOrNickName);


            if (user == null)
                throw new NotFoundException("Email ou NickName não encontrado!");

            if (!user.Password.Equals(request.Password))
                throw new BadRequestException("Senha incorreta!");

            var token = _tokenGenerator.TokenGenerator(user);

            var response = new UserLoginResponse(user, token);

            return response;
        }

        public async Task<UserResponse> RegisterUserAsync(UserRegisterRequest request)
        {
            if (request == null)
                throw new BadRequestException("Os dados do usuario devem ser informados!");

            var user = new User(request.Name, request.NickName, request.Email, request.Password);

            var validateEmail = await _userRepository.GetUserByEmailAsync(request.Email);

            if (validateEmail != null)
                throw new ConflictException("Email já cadastrado no nosso sistema!");

            var validateNick = await _userRepository.GetUserByNickNameAsync(request.NickName);

            if (validateNick != null)
                throw new ConflictException("Esse nickname já está em uso!");

            var userRegister = await _userRepository.RegisterUserAsync(user);

            if (userRegister == null)
                throw new InternalServerErrorException("Problemas para cadastrar usuário, tente novamente!");

            var response = new UserResponse(userRegister);

            return response;
        }

        public async Task<GenericResponse> UpdatePasswordAsync(string idUser, string password)
        {
            if (password == null)
                throw new BadRequestException("A senha não pode ser nula!");

            int.TryParse(idUser, out int id);

            var user = await _userRepository.GetUserByIdAsync(id);

            if (user == null)
                throw new NotFoundException("Usuário não encontrado!");

            user.Password = password;

            var response = await _userRepository.UpdateUserAsync(user);

            if (response == null)
                throw new InternalServerErrorException("Problemas para atualizar a senha do usuário, tente novamente!");

            return new GenericResponse("Senha atualizada com sucesso!");
        }
    }
}
