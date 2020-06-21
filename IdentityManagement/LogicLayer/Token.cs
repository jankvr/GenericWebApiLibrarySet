using Cz.Bkk.Generic.Common.IdentityInterfaces;
using Cz.Bkk.Generic.IdentityManagement.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Cz.Bkk.Generic.IdentityManagement.LogicLayer
{
    internal class Token : IToken
    {
        private readonly IConfiguration configuration;
        private readonly ICurrentDateTime currentDateTime;

        public Token(IConfiguration configuration, ICurrentDateTime currentDateTime)
        {
            this.configuration = configuration;
            this.currentDateTime = currentDateTime;
        }

        public string Generate(IdentityUser user, IList<string> roles)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Security:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("roles", string.Join(',', roles)),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
            };

            var token = new JwtSecurityToken(
                configuration["Security:Issuer"],
                configuration["Security:Audience"],
                claims,
                expires: currentDateTime.Now.AddDays(1),
                signingCredentials: credentials);

            var stringifiedToken = new JwtSecurityTokenHandler().WriteToken(token);

            return stringifiedToken;
        }
    }
}
