using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductService.Database.Entity;

namespace ProductService.Database
{
    public class DatabaseContext: DbContext
    {
        public DbSet<Product> products { get; set; }
        public object Product { get; internal set; }

        public DbSet<Category> category { get; set; }
        public object Category { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source = LAPTOP-V0UGO61O\SQLEXPRESS; initial catalog = Products; persist security info = True; Integrated Security = SSPI;");
        }
    }
}
