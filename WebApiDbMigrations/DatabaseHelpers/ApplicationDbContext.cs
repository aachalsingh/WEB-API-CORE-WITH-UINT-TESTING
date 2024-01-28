using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApiDbMigrations.Models;

namespace WebApiDbMigrations.DatabaseHelpers
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnStr")
        {
            
        } 
        public DbSet<Employee> Employees { get; set; }
        
    }
}