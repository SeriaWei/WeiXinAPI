using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

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
            if (code == null)
            {
                return
                    Redirect(
                        string.Format("https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type=code&scope={2}&state=STATE#wechat_redirect",
                        AppID, "http://seriawei.ngrok.natapp.cn/", "snsapi_base"));
            }
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
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            string s = Request.QueryString["signature"];
            string sig2 = GetSignature(Token, timestamp, nonce);
            if (sig2.Equals(signature))
            {
                Content(echostr);
            }
            return Content(null);
        }
        [HttpPost]
        [ActionName("weixinapi")]
        public JsonResult Post(string signature, string timestamp, string nonce, string echostr)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            string s = Request.QueryString["signature"];
            string sig2 = GetSignature(Token, timestamp, nonce);
            if (sig2.Equals(signature))
            {
                string data = new StreamReader(Request.InputStream).ReadToEnd();
                Response.Write(sig2);
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }
        
    }
}
