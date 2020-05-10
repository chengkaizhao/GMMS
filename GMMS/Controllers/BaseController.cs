using GMMS.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GMMS.Controllers
{
    public class BaseController : Controller
    {
        // 定义授权筛选器所需的方法。
        // 在需要授权时调用。
        // 参数:filterContext:
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            // 对请求进行身份验证,判断用户是否登录
            if (HttpContext.Session["CurentUser"] == null || !(HttpContext.Session["CurentUser"] is User_infor))
            {
                filterContext.Result = new RedirectResult("~/Home/Login");
            }
        }

    }
}