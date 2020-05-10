using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GMMS.Areas.User.Controllers
{
    public class UploadController : Controller
    {
        // GET: User/Upload
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult FilesUpload()
        {
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase f = Request.Files["file"];//最简单的获取方法
                f.SaveAs(AppDomain.CurrentDomain.BaseDirectory + "/Image/" + f.FileName);//保存图片

                //这下面是返回json给前端 
                var data1 = new
                {
                    src = AppDomain.CurrentDomain.BaseDirectory + "/Image/" + f.FileName,//服务器储存路径
                };
                var Person = new
                {
                    code = 0,//0表示成功
                    msg = "",//这个是失败返回的错误
                    data = data1
                };
                return Json(Person);//格式化为json
            }
            else
            {
                return null;
            }


        }
    }
}