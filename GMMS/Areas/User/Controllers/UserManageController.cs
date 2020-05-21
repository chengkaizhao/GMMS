using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GMMS.Controllers;
using GMMS.EF;
using GMMS.Areas.User.Models.User;
using System.Data.Entity.Validation;
using GMMS.Helper;

namespace GMMS.Areas.User.Controllers
{
    public class UserManageController : Controller
    {
        // GET: User/UserManage
        public ActionResult UserView()
        {
            return View();
        }
        public ActionResult GetUserList(int page, int limit)
        {
            using (Dbcontext dbcontext = new Dbcontext())
            {
                var query = dbcontext.User_infor.AsQueryable();
                var pageQuery = query.OrderByDescending(a => a.User_name)
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

        public ActionResult UserDetail(string user_name)
        {
            using (Dbcontext context = new Dbcontext())
            {
                if (user_name == "")
                {
                    return View();
                }
                else
                {
                    User_infor user_Infor = context.User_infor.FirstOrDefault(u => u.User_name == user_name);

                    ViewBag.userInfo = Newtonsoft.Json.JsonConvert.SerializeObject(user_Infor);

                }
            }

            return View();
        }

        public ActionResult SubUserDetail(UserDetailModel user)
        {

            using (Dbcontext context = new Dbcontext())
            {
                User_infor editUser = context.User_infor.FirstOrDefault(u => u.User_name == user.User_name);
                if (editUser == null)
                {
                    User_infor adduser = new User_infor()
                    {
                        User_name = user.User_name,
                        User_pwd = MD5Encrypt.Encrypt(user.User_pwd),
                        User_rank = user.User_rank,
                        User_realname = user.User_realname,
                        UpdataTime = DateTime.Now
                    };
                    context.User_infor.Add(adduser);
                }
                else
                {
                    editUser.User_name = user.User_name;
                    editUser.User_pwd = MD5Encrypt.Encrypt(user.User_pwd);
                    editUser.User_realname = user.User_realname;
                    editUser.UpdataTime = DateTime.Now;
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
        public ActionResult DelUser(string user_name)
        {
            using (Dbcontext context = new Dbcontext())
            {
                User_infor userinfo = context.User_infor.FirstOrDefault(u => u.User_name == user_name );
                context.User_infor.Remove(userinfo);
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
    }
}