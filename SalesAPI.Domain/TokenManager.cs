using API.Common;
using Microsoft.IdentityModel.Tokens;
using SalesAPI.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SalesAPI.Domain
{
    public class TokenManager : ITokenManager
    {
        private readonly JwtSecurityTokenHandler _tokenHandler;
        private readonly byte[] _SecurityKey;
        public TokenManager()
        {
            _tokenHandler = new JwtSecurityTokenHandler();
            _SecurityKey = Encoding.ASCII.GetBytes("RRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR"); // 32 bytes
        }
        public Task<Token> GenerateToken()
        {
            /* Generate the Token with user details and add it in Claims */
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, "Test User Name") }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_SecurityKey),
                                        SecurityAlgorithms.HmacSha256Signature)
            };

            var token = _tokenHandler.CreateToken(tokenDescriptor);
            return Task.FromResult(new Token()
            {
                Value = _tokenHandler.WriteToken(token),
                ExpiryDate = tokenDescriptor.Expires
            });
        }

        public Task<bool> VerifyToken(string token)
        {
            try
            {
                _tokenHandler.ValidateToken(token, new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(_SecurityKey),
                    ValidateLifetime = true,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                return Task.FromResult(true);
            }
            catch
            {
                return Task.FromResult(false);
            }
        }
    }
}