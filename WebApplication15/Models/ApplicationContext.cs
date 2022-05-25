
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication15.Models
{
    public class ApplicationContext :DbContext
    {
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Product> Products  { get; set; } = null!;
        public ApplicationContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();  
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=database-3.cqrandacnrdj.eu-west-2.rds.amazonaws.com;Initial Catalog=USERDB;Persist Security Info=True;User ID=admin;Password=12345qwert;");
        }
    }
}
