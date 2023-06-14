using HomeBrokerSimulator.Domain.Model.Entity;
using HomeBrokerSimulator.Domain.Model.Request;
using HomeBrokerSimulator.Domain.Model.Response;
using HomeBrokerSimulator.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeBrokerSimulator.API.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("/users/")]
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
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(GenericResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(GenericResponse))]
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<ActionResult> RegisterUser([Microsoft.AspNetCore.Mvc.FromBody] UserRegisterRequest request) =>
            Created(nameof(User), await _userService.RegisterUserAsync(request));

        /// <summary>
        /// Realizar login na plataforma
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserLoginResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(GenericResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GenericResponse))]
        [Microsoft.AspNetCore.Mvc.HttpPost("login")]
        public async Task<ActionResult> LoginUser([Microsoft.AspNetCore.Mvc.FromBody] UserLoginRequest request) => 
            Ok(await _userService.LoginUserAsync(request));

        /// <summary>
        /// Busca informações detalhadas do usuário
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(GenericResponse))]
        [Microsoft.AspNetCore.Mvc.HttpGet("details")]
        [Authorize]
        public async Task<ActionResult> GetUserById() =>
            Ok(await _userService.GetUserByIdAsync(User.FindFirst("Id")?.Value));

        /// <summary>
        /// Atualiza a senha do usuário
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserLoginResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(GenericResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(GenericResponse))]
        [Microsoft.AspNetCore.Mvc.HttpPatch("upload-image")]
        public async Task<ActionResult> UpdateUserImage([Microsoft.AspNetCore.Mvc.FromQuery] IFormFile image) =>
            Ok(await _userService.UpdateImageAsync(User.FindFirst("Id")?.Value, image));

        /// <summary>
        /// Deleta a conta do usuário
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenericResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(GenericResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(GenericResponse))]
        [Microsoft.AspNetCore.Mvc.HttpDelete]
        [Authorize]
        public async Task<ActionResult> DeleteUserById() =>
            Ok(await _userService.DeleteUserByIdAsync(User.FindFirst("Id")?.Value));
    }
}
