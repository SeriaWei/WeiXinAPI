using System;
using Newtonsoft.Json;

namespace WeiXinAPI.MP.WebService
{
    public class AccessToken : ErrorMessage
    {
        private readonly DateTime _generateTime;

        public AccessToken()
        {
            _generateTime = DateTime.Now;
        }
        [JsonProperty("access_token")]
        public string Token { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        public bool IsExpire { get { return _generateTime.AddSeconds(ExpiresIn) < DateTime.Now; } }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("openid")]
        public string OpenId { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }

        [JsonProperty("unionid")]
        public string UnionId { get; set; }
    }
}