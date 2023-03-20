using AuthUserToken.Domain.Interface.Service;
using AuthUserToken.Domain.Model.Request;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;

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
        /// Cadastrar um novo usuário
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<ActionResult> RegisterUser([Microsoft.AspNetCore.Mvc.FromBody] UserRegisterRequest request)
        {
            var response = await _userService.RegisterUserAsync(request);

            if (!response.IsSuccess)
                return StatusCode(response.StatusCode, response.Message);

            return StatusCode(response.StatusCode, response.Data);
        }

        /// <summary>
        /// Buscar um usuário por ID
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpGet("{id}")]
        public async Task<ActionResult> GetUserById([Microsoft.AspNetCore.Mvc.FromRoute] int id)
        {
            var response = await _userService.GetUserByIdAsync(id);

            if (!response.IsSuccess)
                return StatusCode(response.StatusCode, response.Message);

            return StatusCode(response.StatusCode, response.Data);
        }
    }
}
