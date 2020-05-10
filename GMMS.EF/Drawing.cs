namespace GMMS.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Drawing")]
    public partial class Drawing
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string Drawing_id { get; set; }

        public DateTime? Drawing_time { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Drawing_title { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string Drawing_author { get; set; }

        [StringLength(50)]
        public string Drawing_type { get; set; }
    }
}
