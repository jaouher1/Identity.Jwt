using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Identity.JwtToken.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Identity.JwtToken.ExtensionsService
{
    public static class IdentityService
    {
        public static void AddIdentityJwt(this IServiceCollection services, IConfiguration configuration , Options opt = null)
        {

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowAnyOrigin()
                        .Build());
            });

            
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); // => remove default claims

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = opt?.ValidateIssuer ?? false,
                    ValidateAudience = opt?.ValidateIssuer ?? false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true, 
                    ValidIssuer = configuration[ opt?.ConfIssuerPath ?? "Jwt:Issuer"],
                    ValidAudience = configuration[opt?.ConfAudiencePath ?? "Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration[opt?.ConfKeyPath ?? "Jwt:Key"]))
                };
            });

        }

    }
}
