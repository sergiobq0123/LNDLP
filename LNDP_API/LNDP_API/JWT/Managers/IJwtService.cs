using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using TTTAPI.JWT.Models;

namespace TTTAPI.JWT.Managers
{
    public interface IJwtService
    {
        bool IsTokenValid(string token);
        string GenerateToken(IJwtContainer model);
        IEnumerable<Claim> GetTokenClaims(string token);
    }
}
