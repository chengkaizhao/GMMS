using GMMS.EF;
using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using GMMS.Helper;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

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
        public ActionResult Enter (string userName, string userPassword)
        {
            using (Dbcontext context = new Dbcontext())
            {
                User_infor userinfo = context.User_infor.FirstOrDefault(u => u.User_name == userName);

                if (userinfo == null)
                {
                    return Json(new
                    {
                        Success = false,
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
            MemoryStream memory = new MemoryStream();
            bitmap.Save(memory, ImageFormat.Gif);
            return File(memory.ToArray(), "image/gif");
        }

    }
}