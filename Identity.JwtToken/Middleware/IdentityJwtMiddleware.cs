using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Identity.JwtToken.Middleware
{
    public class IdentityJwtMiddleware
    {
        private readonly RequestDelegate _next;

        public IdentityJwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next(context);
        }
    }
}
