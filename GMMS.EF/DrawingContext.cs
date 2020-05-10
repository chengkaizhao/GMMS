namespace GMMS.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DrawingContext : DbContext
    {
        public DrawingContext()
            : base("name=DrawingContext")
        {
        }

        public virtual DbSet<User_infor> User_infor { get; set; }
        public virtual DbSet<Drawing> Drawing { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            modelBuilder.Entity<User_infor>()
                .Property(e => e.User_name)
                .IsUnicode(false);

            modelBuilder.Entity<User_infor>()
                .Property(e => e.User_pwd)
                .IsUnicode(false);

            modelBuilder.Entity<User_infor>()
                .Property(e => e.User_realname)
                .IsUnicode(false);

            modelBuilder.Entity<Drawing>()
                .Property(e => e.Drawing_id)
                .IsUnicode(false);

            modelBuilder.Entity<Drawing>()
                .Property(e => e.Drawing_title)
                .IsUnicode(false);

            modelBuilder.Entity<Drawing>()
                .Property(e => e.Drawing_author)
                .IsUnicode(false);
        }
    }
}
