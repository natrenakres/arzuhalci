using System.Security.Claims;

namespace ArzuhalCI.Infrastructure.Authentication;

internal static class ClaimsPrincipalExtensions
{
    public static Guid GetUserId(this ClaimsPrincipal? principal)
    {
        var userId = principal?.FindFirst(x => x.Type == ClaimTypes.NameIdentifier)?.Value
               ?? throw new ApplicationException("User identity is unavailable");

        return Guid.Parse(userId);
    }
    
    public static string GetIdentityId(this ClaimsPrincipal? principal)
    {
        return principal?.FindFirst(x => x.Type == ClaimTypes.NameIdentifier)?.Value
               ?? throw new ApplicationException("User identity is unavailable");
    }
    
}