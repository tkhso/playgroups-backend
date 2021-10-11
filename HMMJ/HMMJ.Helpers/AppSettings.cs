using System;
using System.Collections.Generic;
using System.Text;

namespace HMMJ.Helpers
{
    public class AppSettings
    {
        public JwtSettings Jwt { get; set; }

        public class JwtSettings
        {
            public string Key { get; set; }
            public string Issuer { get; set; }
            public string Audience { get; set; }
        }
    }
}
