using Newtonsoft.Json;

namespace WeiXinAPI.MP.WebService
{
    public class UserInfo : ErrorMessage
    {
        [JsonProperty("openid")]
        public string OpenId { get; set; }

        [JsonProperty("nickname")]
        public string Nickname { get; set; }

        [JsonProperty("sex")]
        public int Sex { get; set; }

        [JsonProperty("province")]
        public string Province { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("headimgurl")]
        public string Headimgurl { get; set; }

        [JsonProperty("unionid")]
        public string UnionId { get; set; }
    }
}