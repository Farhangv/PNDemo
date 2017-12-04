namespace MVCDemo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCDemo.Models.MVCModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MVCDemo.Models.MVCModel context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Users.AddOrUpdate(
                u => u.Username,
                new Models.User() { Name = "John", Family = "Doe", Username = "Manager1", Password = "123", Role = "admin" },
                new Models.User() { Name = "David", Family = "Doe", Username = "Employee1", Password = "123", Role = "normaluser" },
                new Models.User() { Name = "Sarah", Family = "Smith", Username = "Manager2", Password = "123", Role = "admin" },
                new Models.User() { Name = "Joey", Family = "Tribianni", Username = "Employee2", Password = "123", Role = "normaluser" }
                );
        }
    }
}
