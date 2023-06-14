using HomeBrokerSimulator.Domain.Exceptions;
using HomeBrokerSimulator.Domain.Model.Entity;
using HomeBrokerSimulator.Domain.Model.Request;
using HomeBrokerSimulator.Domain.Model.Response;
using HomeBrokerSimulator.Infrastructure.Interface.Authentication;
using HomeBrokerSimulator.Infrastructure.Interface.Repository;
using HomeBrokerSimulator.Service.Interface;
using Microsoft.AspNetCore.Http;

namespace HomeBrokerSimulator.Service.Serivces
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

        public async Task<byte[]> UpdateImageAsync(string idUser, IFormFile image)
        {
            if (image == null)
                throw new BadRequestException("A imagem não pode ser nula!");

            int.TryParse(idUser, out int id);

            var user = await _userRepository.GetUserByIdAsync(id);

            if (user == null)
                throw new NotFoundException("Usuário não encontrado!");

            await using var convertImage = new MemoryStream();
            await image.CopyToAsync(convertImage);

            user.Image = convertImage.ToArray();

            var response = await _userRepository.UpdateUserAsync(user);

            if (response == null)
                throw new InternalServerErrorException("Problemas para atualizar a foto do usuário, tente novamente!");

            return user.Image;
        }
    }
}
