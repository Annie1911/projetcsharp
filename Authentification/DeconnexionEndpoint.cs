using Microsoft.AspNetCore.Identity;
using projetcsharp.Models;
using System.Security.Claims;

namespace projetcsharp.Authentification
{
    internal static class DeconnexionEndpoint
    {
        public static IEndpointConventionBuilder MapDecoEndpoint(this IEndpointRouteBuilder endpoint
            )
        {
            ArgumentNullException.ThrowIfNull(endpoint);
            var accountGroup = endpoint.MapGroup("/compte");
            accountGroup.MapPost("/deconnexion", async (ClaimsPrincipal user, SignInManager<Utilisateur> signInManager) => {
                await signInManager.SignOutAsync();
                return TypedResults.LocalRedirect("/");
            });
            return accountGroup;
        }
    }
}
