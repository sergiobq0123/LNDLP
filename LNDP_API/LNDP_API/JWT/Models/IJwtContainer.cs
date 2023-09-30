using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace TTTAPI.JWT.Models
{
    public interface IJwtContainer
    {
        string SecurityAlgorithm { get; set; }
        int ExpireInMinutes { get; set; }
        Claim[] Claims { get; set; }
    }
}
