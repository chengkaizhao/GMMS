namespace GMMS.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User_infor
    {
        [Key]
        [StringLength(50)]
        public string User_name { get; set; }

        [Required]
        [StringLength(50)]
        public string User_pwd { get; set; }

        [StringLength(50)]
        public string User_realname { get; set; }

        public int? User_rank { get; set; }

        public DateTime? UpdataTime { get; set; }
    }
}
