namespace GMMS.Areas.User.Models.Drawing
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;

    public class DrawingModel
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“DrawingModel”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“GMMS.Areas.User.Models.Drawing.DrawingModel”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“DrawingModel”
        //连接字符串。


        //为您要在模型中包含的每种实体类型都添加 DbSet。有关配置和使用 Code First  模型
        //的详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=390109。
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string   Drawing_id { get; set; }

        public DateTime Drawing_time { get; set; }

        [Required]
        [StringLength(50)]
        public string Drawing_title { get; set; }

        [Required]
        [StringLength(50)]
        public string Drawing_author { get; set; }

        [StringLength(50)]
        public string Drawing_type { get; set; }

        [StringLength(50)]
        public string Drawing_mine { get; set; }
        [StringLength(50)]
        public string Drawing_url { get; set; }
    }

  
}