using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bullhorn.Net
{
    public class BullhornRestCredentials
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public string RestTokenUrl { get; set; }
        public string RestClientId { get; set; }
        public string RestClientSecret { get; set; }

        public string RestLoginUrl { get; set; }
        public int RestSessionMinutesToLive { get; set; }

        public string RestAuthorizeUrl { get; set; }
    }
}
