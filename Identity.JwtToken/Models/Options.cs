using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.JwtToken.Models
{
    public class Options
    {
        public bool ValidateIssuer { get; set; }
        public bool ValidateAudience { get; set; }
        public bool ValidateLifetime { get; set; }
        public bool ValidateIssuerSigningKey { get; set; }
        public string ConfIssuerPath { get; set; }
        public string ConfAudiencePath { get; set; }
        public string ConfKeyPath { get; set; }
    }
}
