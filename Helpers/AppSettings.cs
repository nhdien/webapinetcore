using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPINetCore.Helpers
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public int RefreshTokenTimeToLive { get; set; }
    }
}
