using Newtonsoft.Json;

namespace WeiXinAPI.MP
{
    public class ErrorMessage
    {
        [JsonProperty("errcode")]
        public string Code { get; set; }
        [JsonProperty("errmsg")]
        public string Message { get; set; }
    }
}