using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace WeiXinAPI.MP.WebService
{
    public class Authorize
    {
        public const string AuthorizeUrl = "https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type=code&scope={2}&state=STATE#wechat_redirect";
        public const string AccessTokenUrl = "https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code";
        public const string RefreshAccessTokenUrl = "https://api.weixin.qq.com/sns/oauth2/refresh_token?appid={0}&grant_type=refresh_token&refresh_token={1}";
        public const string UserInfoUrl = "https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}&lang=zh_CN";

        public const string SnsapiBase = "snsapi_base";
        public const string SnsapiUserinfo = "snsapi_userinfo";

        public static string GetAuthorizeUrl(string appid, string redirectUrl, string scope)
        {
            return string.Format(AuthorizeUrl, appid, redirectUrl, scope);
        }

        public static AccessToken GetAccessToken(string appid, string appSecret, string code)
        {
            WebClient client = new WebClient();
            string jsonResult = client.DownloadString(string.Format(AccessTokenUrl, appid, appSecret, code));
            var token = JsonConvert.DeserializeObject<AccessToken>(jsonResult);
            return token;
        }

        public static AccessToken RefreshAccessToken(string appid, string refreshToken)
        {
            WebClient client = new WebClient();
            string jsonResult = client.DownloadString(string.Format(RefreshAccessTokenUrl, appid, refreshToken));
            var token = JsonConvert.DeserializeObject<AccessToken>(jsonResult);
            return token;
        }

        public static UserInfo GetUserInfo(string token, string openId)
        {
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;
            string jsonResult = client.DownloadString(string.Format(UserInfoUrl, token, openId));
            var user = JsonConvert.DeserializeObject<UserInfo>(jsonResult);
            return user;
        }
    }
}
