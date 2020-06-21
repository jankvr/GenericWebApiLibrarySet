using Cz.Bkk.Generic.IdentityManagement.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Cz.Bkk.Generic.IdentityManagement.Models
{
    /// <summary>
    /// Extended IdentityUser class
    /// </summary>
    internal class CurrentlyLoggedUser : ICurrentlyLoggedUser
    {
        public string UserName { get; }

        public string Id { get; }

        public string Roles { get; }

        public CurrentlyLoggedUser(IHttpContextAccessor httpContextAccessor)
        {
            UserName = httpContextAccessor.HttpContext.User.Claims.Where(x => x.Type == JwtRegisteredClaimNames.Sub).FirstOrDefault()?.Value;
            Id = httpContextAccessor.HttpContext.User.Claims.Where(x => x.Type == JwtRegisteredClaimNames.Jti).FirstOrDefault()?.Value;
            Roles = httpContextAccessor.HttpContext.User.Claims.Where(x => x.Type == "role").FirstOrDefault()?.Value;
        }
    }
}
