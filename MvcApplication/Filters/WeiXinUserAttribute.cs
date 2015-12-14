using System;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcApplication.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class WeiXinUserAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var request = filterContext.HttpContext.Request as HttpRequestWrapper;
            if (request != null)
            {
                var app = new WeiXinAPI.MP.Application("wx4dbf1515eb19ea47", "a1c8aca9e20266ff6ff35dac9c83dffd", "weixinapi");
                string code = request.QueryString["code"];
                if (!string.IsNullOrEmpty(code) && !request.IsAuthenticated)
                {
                    var user = app.GetUserInfo(code);
                    if (user.OpenId != null)
                    {
                        FormsAuthentication.SetAuthCookie(user.OpenId, false);
                    }
                    else
                    {
                        throw new Exception("获取用户信息失败");
                    }
                }
                if (!request.IsAuthenticated)
                {
                    filterContext.Result = new RedirectResult(app.GetWebAuthorizeUrl("http://seriawei.ngrok.natapp.cn", WeiXinAPI.MP.WebService.Authorize.SnsapiUserinfo));
                }
            }
        }
    }
}