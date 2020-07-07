using System;

namespace CoreApi.Security.Token
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiriation { get; set; }
        public string RefreshToken { get; set; }
    }
}