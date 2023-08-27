using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoneyAdministratorBackend.Dtos;
using MoneyAdministratorBackend.Services;
using MoneyAdministratorBackend.Utilities;
using System.IdentityModel.Tokens.Jwt;
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
        public async Task<IActionResult> CheckIsLogin()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userService.GetUserDetailsById(userId);

            return Ok(user);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserAuthDto userDto)
        {
            try
            {
                var token = await _userService.Register(userDto.Username, userDto.Password, userDto.DisplayName);
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,  // usar solo en HTTPS
                    SameSite = SameSiteMode.None  // previene el envío de la cookie en solicitudes cross-site
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
                    SameSite = SameSiteMode.None  // previene el envío de la cookie en solicitudes cross-site
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
