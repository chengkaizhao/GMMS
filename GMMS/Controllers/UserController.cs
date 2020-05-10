using GMMS.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GMMS.Controllers
{
    public class UserController : BaseController
    {
        //此控制器继承自BaseController，需要登录验证
        public ActionResult Index()
        {
            return View();
        }
        //public ActionResult Drawing(string a, string b, DateTime c, int d)
        //{
        //    using (Dbcontext drawingcontext = new Dbcontext())
        //    {
        //        User_drawing drawing = drawingcontext.User_drawing.FirstOrDefault(u => u.Drawing_id == d);

        //        drawing.Drawing_title = a;
        //        drawing.Drawing_author = b;
        //        drawing.Drawing_time = c;

        //    }
        //    return View();
        //}
    }
}