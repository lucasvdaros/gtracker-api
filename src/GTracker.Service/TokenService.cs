using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using GTracker.Domain.DTO.User;
using GTracker.Domain.Interface.Service;
using GTracker.Domain.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace GTracker.Service
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _Configuration;

        public TokenService(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        public LoginResponseUserDTO TokenObject(UserDTO user)
        {
            var appSettingsSection = _Configuration.GetSection("AppSettings");
            var tokenSettings = appSettingsSection.Get<TokenConfiguration>();            
            var key = Encoding.ASCII.GetBytes(tokenSettings.Key);
            var handler = new JwtSecurityTokenHandler();

            var identity = new ClaimsIdentity(
                new GenericIdentity(user.Name),
                new[]
                {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Actort, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Login)
                }
            );

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate + TimeSpan.FromMinutes(tokenSettings.Minuts);

            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = tokenSettings.Issuer,
                Audience = tokenSettings.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Subject = identity,
                NotBefore = createDate,
                IssuedAt = createDate,
                Expires = expirationDate
            });

            var token = handler.WriteToken(securityToken);

            return new LoginResponseUserDTO
            {
                Authenticated = true,
                AccessToken = token
            };
        }
    }
}