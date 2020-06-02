using GMMS.Areas.User.Models.Drawing;
using GMMS.EF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GMMS.Areas.User.Controllers
{
    public class DrawingController : Controller
    {
        // GET: User/Drawing
        public ActionResult DrawingView()
        {
            return View();
        }

        public ActionResult GetDrawingList(int page, int limit)
        {
            using (DrawingContext context = new DrawingContext())
            {
                var query = context.Drawing.AsQueryable();
                var pageQuery = query.OrderByDescending(a => a.Drawing_id)
                    .Skip(limit * (page - 1)).Take(limit).ToList();


                var result = new
                {
                    code = 0,
                    msg = "",
                    count = query.Count(),
                    data = pageQuery
                };

                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult DrawingDetail(string  drawing_guid)
        {
            using (DrawingContext context = new DrawingContext())
            {
                    Drawing drawing = context.Drawing.FirstOrDefault(u => u.Drawing_id == drawing_guid);

                    ViewBag.drawing = Newtonsoft.Json.JsonConvert.SerializeObject(drawing);

                
            }

            return View();
        }

        public ActionResult SubDrawingDetail(DrawingModel drawing)
        {

            using (DrawingContext context = new DrawingContext())
            {
                Drawing editDrawing = context.Drawing.FirstOrDefault(u => u.Drawing_id== drawing.Drawing_id);
                if (editDrawing == null)
                {
                    Drawing addrawing = new Drawing()
                    {
                        Drawing_id=Guid.NewGuid().ToString(),
                        Drawing_author = drawing.Drawing_author,
                        Drawing_title = drawing.Drawing_title,
                        Drawing_time = DateTime.Now,
                        Drawing_type=drawing.Drawing_type,
                        Drawing_mine=drawing.Drawing_mine,
                        Drawing_url=drawing.Drawing_url,
                    };
                    context.Drawing.Add(addrawing);
                }
                else
                {
                    editDrawing.Drawing_id = drawing.Drawing_id;
                    editDrawing.Drawing_title = drawing.Drawing_title;
                    editDrawing.Drawing_author = drawing.Drawing_author;
                    editDrawing.Drawing_time = DateTime.Now;
                    editDrawing.Drawing_type = drawing.Drawing_type;
                    editDrawing.Drawing_mine = drawing.Drawing_mine;
                }

                int flg = context.SaveChanges();
                if (flg > 0)
                {
                    return Json(new
                    {
                        Success = true,
                        Message = "操作成功"
                    });
                }
                return Json(new
                {
                    Success = false,
                    Message = "操作失败"
                });


            }
        }
        public ActionResult DelDrawing(string drawingid)
        {
            using (DrawingContext context = new DrawingContext())
            {
                Drawing drawing = context.Drawing.FirstOrDefault(u => u.Drawing_id== drawingid);
                context.Drawing.Remove(drawing);
                if (context.SaveChanges() > 0)
                {
                    return Json(new
                    {

                        Success = true,
                        Message = "删除成功"
                    });
                }
                return Json(new
                {
                    Success = false,
                    Message = "删除失败"
                });
            }
        }
        public ActionResult Upload()
        {
            return View();
        }
        /// <summary>
        /// 上传文件
        /// </summary>
        
        [HttpPost]
        public ActionResult File(HttpPostedFileWrapper file)
        {
            file.SaveAs(Path.Combine(Server.MapPath("/images"), Path.GetFileName(file.FileName)));//用Server.MapPath获得相对路径的物理路径
            return Json("上传成功");

            //string  filePath = Path.Combine(HttpContext.Server.MapPath("../images"),Path.GetFileName(file.FileName));
            //file.SaveAs(filePath);
            //return Json("上传成功");

            //HttpPostedFileBase f = Request.Files["file"];//最简单的获取方法
            //f.SaveAs(AppDomain.CurrentDomain.BaseDirectory + "/Image/" + f.FileName);//保存图片

            ////这下面是返回json给前端 
            //var data1 = new
            //{
            //    src = AppDomain.CurrentDomain.BaseDirectory + "/Image/" + f.FileName,//服务器储存路径
            //};
            //var Person = new
            //{
            //    code = 0,//0表示成功
            //    msg = "",//这个是失败返回的错误
            //    data = data1
            //};
            //return Json(Person);//格式化为json
        }
    }
}