using System;
using Newtonsoft.Json;

namespace WeiXinAPI.MP
{
    public class AccessToken
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
    }
}