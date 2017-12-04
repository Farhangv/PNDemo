namespace MVCDemo.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MVCModel : DbContext
    {
        public MVCModel()
            : base("MVCModel")
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    

}