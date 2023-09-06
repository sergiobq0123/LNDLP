using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LNDP_API.Data;
using LNDP_API.Models;
using Microsoft.IdentityModel.Tokens;

namespace LNDP_API.Services {
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _ssKey;
        private readonly APIContext _context;

        public TokenService(IConfiguration config, APIContext context)
        {
            _ssKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Token"]));
            _context = context;
        }
        public string CreateToken(User user)
        {
            var claims = new Claim[]
            {
                new Claim("userID", user.Id.ToString()),
                new Claim("username", user.Username.ToString()),
                new Claim("role", user.Role.ToString()),
            };

            var credentials = new SigningCredentials(_ssKey, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        
    }
}