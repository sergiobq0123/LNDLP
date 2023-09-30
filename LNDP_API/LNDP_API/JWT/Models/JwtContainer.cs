using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace TTTAPI.JWT.Models
{
    public class JwtContainer : IJwtContainer
    {
        public string SecurityAlgorithm { get; set; } = SecurityAlgorithms.HmacSha256Signature;
        public int ExpireInMinutes { get; set; } = 1440; // 1 day
        public Claim[] Claims { get; set; }
    }
}
