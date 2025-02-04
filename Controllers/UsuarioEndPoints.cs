using GestionPedidos.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace GestionPedidosAPI.Controllers
{
    public static class UsuarioEndPoints
    {
        public static IEndpointRouteBuilder MapUsuarioEndPoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/PerfilUsuario", GetPerfilUsuario);
            
            return app;
        }

        [Authorize]
        private static async Task<IResult> GetPerfilUsuario(
            UserManager<Usuario> userManager,
            ClaimsPrincipal user)
        {
            string userId = user.Claims.First(x => x.Type == "UserId").Value;

            var userDetails = await userManager.FindByIdAsync(userId);

            return Results.Ok(
                new
                {
                    Email = userDetails?.Email,
                    Nombre = userDetails?.UserName
                });
        }
    }
}
