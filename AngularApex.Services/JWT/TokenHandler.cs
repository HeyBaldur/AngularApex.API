using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AngularApex.Services.JWT
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration _iConfiguration;

        public TokenHandler(IConfiguration iConfiguration)
        {
            _iConfiguration = iConfiguration;
        }

        public string GenerateToken(
            int userId, 
            string emailAddress, 
            string accountId, 
            string license)
        {
            // Set claims
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Email, emailAddress),
                new Claim("id", userId.ToString()),
                new Claim(nameof(accountId), accountId),
                new Claim(nameof(license), license),
                new Claim("issuerUrl", "http://localhost:4200/"), // Change this URL for PROD.
            };

            // Set key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_iConfiguration.GetSection("AppSettings:Token").Value));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(100), // In prod this number should be change to different amount of days
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            string tokenValue = tokenHandler.WriteToken(token);

            return tokenValue;
        }
    }
}
