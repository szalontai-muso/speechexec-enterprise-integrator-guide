using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileAPITest.Data
{
    internal class OAuthTokenResponse
    {
        public string? access_token { get; set; }
        public string? token_type { get; set; }
        public int expires_in { get; set; }
        public string? userName { get; set; }
        public string? roles { get; set; }
        public string? userAccountId { get; set; }
        public string? authenticatedUserNameValue { get; set; }
    }
}
