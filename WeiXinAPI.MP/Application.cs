using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using WeiXinAPI.MP.Message;

namespace WeiXinAPI.MP
{
    public class Application
    {
        private static readonly Dictionary<string, AccessToken> Tokens = new Dictionary<string, AccessToken>();

        private const string TokenUrl = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}";
        public Application(string appId, string sppSecret, string token)
        {
            this.AppId = appId;
            this.AppSecret = sppSecret;
            this.Token = token;
        }

        public string AppId { private set; get; }
        public string AppSecret { private set; get; }
        public string Token { private set; get; }

        public AccessToken GetToken()
        {
            string key = AppId + "_" + AppSecret;
            lock (Tokens)
            {
                if (Tokens.ContainsKey(key))
                {
                    var token = Tokens[key];
                    if (token.IsExpire)
                    {
                        Tokens.Remove(key);
                    }
                    else
                    {
                        return token;
                    }
                }
            }
            WebClient client = new WebClient();
            var json = client.DownloadString(string.Format(TokenUrl, AppId, AppSecret));
            var newtoken = JsonConvert.DeserializeObject<AccessToken>(json);
            if (newtoken.Token == null)
            {
                var errorMsg = JsonConvert.DeserializeObject<ErrorMessage>(json);
                throw new Exception("获取Token错误:" + errorMsg.Code + ":" + errorMsg.Message);
            }
            lock (Tokens)
            {
                Tokens.Add(key, newtoken);
            }
            return newtoken;
        }

        public MessageBase GetMessage(Stream stream)
        {
            return new MessageProvider(stream).Parse();
        }
    }
}