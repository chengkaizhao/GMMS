using GMMS.EF;
using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using GMMS.Helper;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Web.Caching;
using GMMS.Models;
using System;

namespace GMMS.Controllers
{
    public class HomeController : Controller
    {
        

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Upload()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Download()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            
            return View();
        }
        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPassword"></param>
        /// <returns></returns>
        public ActionResult Enter (string userName, string userPassword, string verifyCode)
        {
            using (Dbcontext context = new Dbcontext())
            {
                // 第一步检验验证码
                // 从缓存获取验证码作为校验基准  
                // 先用当前类的全名称拼接上字符串 “verifyCode” 作为缓存的key
                Cache cache = new Cache();
                var verifyCodeKey = $"{this.GetType().FullName}_verifyCode";
                object cacheobj = cache.Get(verifyCodeKey);
                if (cacheobj == null)
                {
                    return Json(new 
                    {
                        success = false,
                        Message = "验证码已失效"
                    }, JsonRequestBehavior.AllowGet);
                }// 不区分大小写 比较
                else if (!(cacheobj.ToString().Equals(verifyCode, StringComparison.CurrentCultureIgnoreCase)))
                {
                    return Json(new 
                    {
                        success = false,
                        Message = "验证码错误"
                    }, JsonRequestBehavior.AllowGet);
                }
                cache.Remove(verifyCodeKey);
                User_infor userinfo = context.User_infor.FirstOrDefault(u => u.User_name == userName);

                if (userinfo == null)
                {
                    return Json(new 
                    {
                        success = false,
                        Message = "当前用户不存在",
                    }, JsonRequestBehavior.AllowGet);
                }
                if ( MD5Encrypt.Encrypt (userPassword) !=userinfo.User_pwd)
                {
                    return Json(new 
                    {
                        success = false,
                        Message = "密码错误",
                    }, JsonRequestBehavior.AllowGet);
                }

                //用session确认用户已经登录
                HttpContext.Session["CurentUser"] = userinfo;
                HttpContext.Session.Timeout = 2;

                return Json(new 
                {
                    success = true,
                    Message = "登录成功",
                }, JsonRequestBehavior.AllowGet);



            }

        }
        public ActionResult VerifyCode()
        {
            string verifyCode = string.Empty;
            Bitmap bitmap = VerifyCodeHelper.CreateVerifyCode(out verifyCode);

            #region 缓存Key 
            Cache cache = new Cache();
            // 先用当前类的全名称拼接上字符串 “verifyCode” 作为缓存的key
            var verifyCodeKey = $"{this.GetType().FullName}_verifyCode";
            cache.Remove(verifyCodeKey);
            cache.Insert(verifyCodeKey, verifyCode);
            #endregion
            MemoryStream memory = new MemoryStream();
            bitmap.Save(memory, ImageFormat.Gif);
            return File(memory.ToArray(), "image/gif");
        }

    }
}