using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using TTTAPI.JWT.Models;

namespace TTTAPI.JWT.Managers
{
    public interface IJwtService
    {
        string GenerateToken(IJwtContainer model);
        ClaimsPrincipal GetValidToken(string token);
    }
}
