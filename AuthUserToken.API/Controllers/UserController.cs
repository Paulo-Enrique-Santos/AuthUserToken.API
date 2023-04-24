using AuthUserToken.Domain.Interface.Service;
using AuthUserToken.Domain.Model.Request;
using AuthUserToken.Domain.Model.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthUserToken.API.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("/Usuarios/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserResponse))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<ActionResult> RegisterUser([Microsoft.AspNetCore.Mvc.FromBody] UserRegisterRequest request)
        {
            var response = await _userService.RegisterUserAsync(request);

            if (!response.IsSuccess)
                return StatusCode(response.StatusCode, response.Message);

            return StatusCode(response.StatusCode, response.Data);
        }

        /// <summary>
        /// Validar login
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserLoginResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [Microsoft.AspNetCore.Mvc.HttpPost("Login")]
        public async Task<ActionResult> LoginUser([Microsoft.AspNetCore.Mvc.FromBody] UserLoginRequest request)
        {
            var response = await _userService.LoginUserAsync(request);

            if (!response.IsSuccess)
                return StatusCode(response.StatusCode, response.Message);

            return StatusCode(response.StatusCode, response.Data);
        }

        /// <summary>
        /// Busca um usuário por id
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [Microsoft.AspNetCore.Mvc.HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult> GetUserById([Microsoft.AspNetCore.Mvc.FromRoute] int id)
        {
            var response = await _userService.GetUserByIdAsync(id);

            if (!response.IsSuccess)
                return StatusCode(response.StatusCode, response.Message);

            return StatusCode(response.StatusCode, response.Data);
        }

        /// <summary>
        /// Atualiza a senha de um usuário
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserLoginResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [Microsoft.AspNetCore.Mvc.HttpPatch("{id}")]
        public async Task<ActionResult> UpdateUserPassword([Microsoft.AspNetCore.Mvc.FromRoute] int id, [Microsoft.AspNetCore.Mvc.FromBody] string password)
        {
            var request = new UserForgotPasswordRequest 
            {
                IdUser = id,  
                Password = password 
            };

            var response = await _userService.UpdatePasswordAsync(request);

            if (!response.IsSuccess)
                return StatusCode(response.StatusCode, response.Message);

            return StatusCode(response.StatusCode, response.Data);
        }

        /// <summary>
        /// Deleta um usuário por id
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [Microsoft.AspNetCore.Mvc.HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteUserById([Microsoft.AspNetCore.Mvc.FromRoute] int id)
        {
            var response = await _userService.DeleteUserByIdAsync(id);

            if (!response.IsSuccess)
                return StatusCode(response.StatusCode, response.Message);

            return StatusCode(response.StatusCode, response.Data);
        }
    }
}
