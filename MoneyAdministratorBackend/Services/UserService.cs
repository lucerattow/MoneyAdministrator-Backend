using Azure;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using MoneyAdministratorBackend.Data;
using MoneyAdministratorBackend.Dtos;
using MoneyAdministratorBackend.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MoneyAdministratorBackend.Services
{
    public class UserService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserService(IConfiguration configuration, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<string> Register(string Username, string password)
        {
            var user = new User 
            { 
                UserName = Username, 
                Email = Username 
            };

            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                return GenerateJwtToken(user);
            }

            string errors = "";
            foreach (var error in result.Errors)
                errors += ErrorCodeTranslator(error.Code) + Environment.NewLine;

            if (!string.IsNullOrEmpty(errors))
                throw new Exception(errors);

            throw new Exception("Error desconocido al intentar registrar un usuario");
        }

        public async Task<string> Login(string Username, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(Username, password, false, false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(Username);
                return GenerateJwtToken(user);
            }
            else
                throw new Exception("Error en las credenciales.");
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sid, user.Id),
                new Claim(JwtRegisteredClaimNames.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtSettings:ExpireDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtSettings:Issuer"],
                _configuration["JwtSettings:Issuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string ErrorCodeTranslator(string code)
        {
            switch (code)
            {
                case "DuplicatedUserName":
                    return "El nombre de usuario ya ha sido registrado";
                case "DuplicatedEmail":
                    return "El correo electrónico ya ha sido registrado";
                case "InvalidUserName":
                    return "El nombre de usuario es inválido (puede que no cumpla con el formato requerido)";
                case "InvalidEmail":
                    return "El correo electrónico es inválido";
                case "InvalidPassword":
                    return "La contraseña es inválida (puede que no cumpla con las políticas de contraseña)";
                case "PasswordTooShort":
                    return "La contraseña es demasiado corta";
                case "PasswordRequiresNonAlphanumeric":
                    return "La contraseña debe contener al menos un carácter no alfanumérico";
                case "PasswordRequiresDigit":
                    return "La contraseña debe contener al menos un dígito numérico";
                case "PasswordRequiresLower":
                    return "La contraseña debe contener al menos una letra minúscula";
                case "PasswordRequiresUpper":
                    return "La contraseña debe contener al menos una letra mayúscula";
                case "UserAlreadyHasPassword":
                    return "El usuario ya tiene una contraseña establecida";
                case "UserLockoutNotEnabled":
                    return "El bloqueo de usuario no está habilitado";
                case "UserAlreadyInRole":
                    return "El usuario ya tiene el rol especificado";
                case "UserNotInRole":
                    return "El usuario no tiene el rol especificado";
                case "RoleNotFound":
                    return "El rol especificado no fue encontrado";
                case "LoginAlreadyAssociated":
                    return "El inicio de sesión ya está asociado con un usuario";
                case "InvalidToken":
                    return "El token proporcionado es inválido";
                case "ConcurrencyFailure":
                    return "Error de concurrencia, el usuario ya ha sido actualizado";
                default:
                    return "Error desconocido";
            }
        }
    }
}
