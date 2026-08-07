using EMPMAL;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APRAPI
{
    public class JwtUtils : IJwtUtils
    {
        private readonly IConfiguration _configuration;

        public JwtUtils(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // ✅ Validate token and extract user info
        public User? ValidateToken(string token, bool ignoreExpiry = false)
        {
            if (string.IsNullOrEmpty(token))
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);

                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = !ignoreExpiry,

                    ValidIssuer = _configuration["Jwt:Issuer"],
                    ValidAudience = _configuration["Jwt:Audience"],

                    IssuerSigningKey = new SymmetricSecurityKey(key),

                    ClockSkew = TimeSpan.Zero
                },
                out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;

                // ✅ Extract claims (NO DB required)
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "U01X01").Value);
                var loginId = jwtToken.Claims.First(x => x.Type == "U01X03").Value;
                var userRole = jwtToken.Claims.First(x => x.Type == "U01X05").Value;

                return new User
                {
                    U01F01 = userId,
                    U01F03 = loginId,
                    U01F05 = userRole
                };
            }
            catch
            {
                return null;
            }
        }

        // ✅ Optional: Extract user directly from HttpContext (BEST PRACTICE)
        public User? GetUserFromClaims(ClaimsPrincipal user)
        {
            if (user == null || !user.Identity.IsAuthenticated)
                return null;

            return new User
            {
                U01F01 = int.Parse(user.FindFirst("U01X01")?.Value ?? "0"),
                U01F03 = user.FindFirst("U01X03")?.Value,
                U01F05 = user.FindFirst("U01X05")?.Value
            };
        }
    }

    public interface IJwtUtils
    {
        User? ValidateToken(string token, bool ignoreExpiry = false);

        User? GetUserFromClaims(ClaimsPrincipal user);
    }
}