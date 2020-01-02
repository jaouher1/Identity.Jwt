using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Builder;

namespace Identity.JwtToken.BuilderExtensions
{
   public static class Builder
    {
        public static IApplicationBuilder UsePeakSign(this IApplicationBuilder builder)
        {
           return builder.UseCors("CorsPolicy");
           
        }
    }
}
