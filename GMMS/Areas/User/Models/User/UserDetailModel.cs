namespace GMMS.Areas.User.Models.User
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;

    public class UserDetailModel 
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“UserDetailModel”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“GMMS.Areas.User.Models.User.UserDetailModel”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“UserDetailModel”
        //连接字符串。
        [Key]
        [StringLength(50)]
        public string User_name { get; set; }

        [Required]
        [StringLength(50)]
        public string User_pwd { get; set; }
        public string User_realname { get; set; }

        public int? User_rank { get; set; }

        public DateTime? UpdataTime { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}