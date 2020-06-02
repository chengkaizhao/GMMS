using System;
using System.Collections.Generic;
using System.IO;
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
                HttpPostedFileBase file = Request.Files["file"];//最简单的获取方法
                file.SaveAs(Path.Combine(Server.MapPath("/images"), Path.GetFileName(file.FileName)));//用Server.MapPath获得相对路径的物理路径

                //这下面是返回json给前端 
                var data1 = new
                {
                    src = AppDomain.CurrentDomain.BaseDirectory + "/images/" + file.FileName,//服务器储存路径
                };
                var Person = new
                {
                    code = 0,//0表示成功
                    msg = "",//这个是失败返回的错误
                    data = data1.src.ToString()
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