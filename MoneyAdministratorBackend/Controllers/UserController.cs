using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoneyAdministratorBackend.Dtos;
using MoneyAdministratorBackend.Services;
using System.Security.Claims;

namespace MoneyAdministratorBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("session_check")]
        [Authorize]  // Asegúrate de que el usuario esté autenticado
        public IActionResult CheckIsLogin()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Obtiene el ID del usuario
            var userName = User.FindFirstValue(ClaimTypes.Name); // Obtiene el nombre de usuario

            var response = new UserResponseDto
            {
                Id = userId,
                Username = userName
            };

            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserAuthDto userDto)
        {
            try
            {
                var token = await _userService.Register(userDto.Username, userDto.Password);
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,  // usar solo en HTTPS
                    SameSite = SameSiteMode.Strict  // previene el envío de la cookie en solicitudes cross-site
                };
                Response.Cookies.Append("token", token, cookieOptions);

                return Ok(new { Message = "Usuario registrado" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserAuthDto userDto)
        {
            try
            {
                var token = await _userService.Login(userDto.Username, userDto.Password);
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,  // usar solo en HTTPS
                    SameSite = SameSiteMode.Strict  // previene el envío de la cookie en solicitudes cross-site
                };
                Response.Cookies.Append("token", token, cookieOptions);

                return Ok(new { Message = "Usuario autenticado" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _userService.Logout();
            return Ok(new { Message = "Sesión cerrada" });
        }
    }
}
