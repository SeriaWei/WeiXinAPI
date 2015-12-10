using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WeiXinAPI.MP;
using WeiXinAPI.MP.Message;

namespace MvcApplication.Controllers
{
    public class HomeController : Controller
    {
        public const string AppID = "wx4dbf1515eb19ea47";
        public const string AppSecret = "a1c8aca9e20266ff6ff35dac9c83dffd";
        public const string Token = "weixinapi";
        public ActionResult Index(string code)
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            //if (code == null)
            //{
            //    return
            //        Redirect(
            //            string.Format("https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type=code&scope={2}&state=STATE#wechat_redirect",
            //            AppID, "http://seriawei.ngrok.natapp.cn/", "snsapi_base"));
            //}
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        [ActionName("weixinapi")]
        public ContentResult Get(string signature, string timestamp, string nonce, string echostr)
        {
            if (Common.Check(signature, Token, timestamp, nonce))
            {
                Content(echostr);
            }
            return Content(null);
        }

        [HttpPost]
        [ActionName("weixinapi")]
        public ContentResult Post(string signature, string timestamp, string nonce, string echostr)
        {
            if (Common.Check(signature, Token, timestamp, nonce))
            {
                var app = new Application(AppID, AppSecret, Token);
                var msg = app.GetMessage(Request.InputStream);
                string res = msg.FromUserName;
                msg.FromUserName = msg.ToUserName;
                msg.ToUserName = res;
                return Content(msg.ToString());
            }

            return Content(null);
        }

    }
}
