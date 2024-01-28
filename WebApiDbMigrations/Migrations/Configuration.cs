namespace WebApiDbMigrations.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApiDbMigrations.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApiDbMigrations.DatabaseHelpers.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApiDbMigrations.DatabaseHelpers.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            var Employees = new List<Employee>
            {
              new Employee {FirstName = "Roshan", LastName="Hi", Gender="Male", City="Pune"},
              new Employee {FirstName = "Sahil", LastName="gnhh", Gender="Male", City="Jaipur"},
              new Employee {FirstName = "Shikast", LastName="Ali", Gender="Male", City="New Delhi"},
              new Employee {FirstName = "Anna", LastName="Rose", Gender="Female", City="Pune"},
              new Employee {FirstName = "Ro", LastName="kkk", Gender="Female", City="Pune"},
            };
            Employees.ForEach(e => context.Employees.AddOrUpdate(e));
            context.SaveChanges();
        }
    }
}
