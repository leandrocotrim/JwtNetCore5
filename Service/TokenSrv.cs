using CrossCutting.DTOs;
using CrossCutting.Interfaces.Services;
using CrossCutting.ValueObjects;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class TokenSrv : ITokenSrv
    {
        public Task<string> Generate(UserResponse user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var claims = user.Roles.Select(role => new Claim(ClaimTypes.Role, role)).ToList();
            claims.Insert(0, new Claim(ClaimTypes.Name, user.Username));
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(SettingsJWT.SECRET_HASH), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Task.FromResult(tokenHandler.WriteToken(token));
        }
    }
}
