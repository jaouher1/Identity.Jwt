using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.JwtToken.Models
{
    public class TokenOptions
    {
        public long ValidTimeInMinute { get; set; }
        public string ConfKeyPath { get; set; }
        public string ConfIssuerPath { get; set; }
        public string ConfAudiencePath { get; set; }
    }
}
