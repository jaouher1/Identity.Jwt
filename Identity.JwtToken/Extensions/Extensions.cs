using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Identity.JwtToken.Extensions
{
   public static class Extensions
    {

        public static string GenerateJwtToken(this IdentityUser user , IConfiguration configuration , TokenOptions options = null)
        {
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
    
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration[options?.ConfKeyPath ?? "Jwt:Key"]));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(configuration[options?.ConfIssuerPath ?? "Jwt:Issuer"],
                    configuration[options?.ConfAudiencePath ?? "Jwt:Audience"],
                    claims,
                    expires: DateTime.Now.AddMinutes(options?.ValidTimeInMinute ?? 30),
                    signingCredentials: credentials);
                return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }

   public class TokenOptions
   {
       public long ValidTimeInMinute { get; set; }
       public string ConfKeyPath { get; set; }
       public string ConfIssuerPath { get; set; }
       public string ConfAudiencePath { get; set; }
   }
}
