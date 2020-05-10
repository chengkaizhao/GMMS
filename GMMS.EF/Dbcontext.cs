namespace GMMS.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Dbcontext : DbContext
    {
        public Dbcontext()
            : base("name=Dbcontext")
        {
        }
        public virtual DbSet<User_infor> User_infor { get; set; }

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
        }
    }
}
