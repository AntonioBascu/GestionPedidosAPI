using GestionPedidos.Data;
using GestionPedidosAPI.Utilities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GestionPedidosAPI.Controllers
{
    public static class UsuarioIdentityEndPoints
    {
        public static IEndpointRouteBuilder MapUsuarioIdentityEndpoints(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapIdentityApi<Usuario>();

            //SIGN UP
            endpoints.MapPost("/signup", CrearUsuario);

            //SIGN IN
            endpoints.MapPost("/signin", IniciarSesion);

            return endpoints;
        }

        private static async Task<IResult> CrearUsuario(
            UserManager<Usuario> userManager,
            [FromBody] RegistroUsuarioModel registroUsuarioModel)
        {
            Usuario usuario = new Usuario()
            {
                UserName = registroUsuarioModel.UserName,
                Email = registroUsuarioModel.Email
            };

            var resultado = await userManager.CreateAsync(usuario, registroUsuarioModel.Password);

            if (resultado.Succeeded) return Results.Ok(resultado);
            else return Results.BadRequest(resultado);
        }

        private static async Task<IResult> IniciarSesion(
            UserManager<Usuario> userManager,
            [FromBody] LoginModel loginModel,
            IOptions<AppSettings> appSettings)
        {
            var user = await userManager.FindByEmailAsync(loginModel.UserNameOrEmail);

            if (user == null) user = await userManager.FindByNameAsync(loginModel.UserNameOrEmail);

            if (user != null && await userManager.CheckPasswordAsync(user, loginModel.Password))
            {
                var signInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.Value.JWTSecret));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserId", user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(10),
                    SigningCredentials = new SigningCredentials(signInKey, SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);

                return Results.Ok(new { token });
            }
            else
            {
                return Results.BadRequest(new { message = "Email o contraseña incorrectos." });
            }
        }
    }
}
