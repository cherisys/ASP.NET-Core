using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataApp.Models
{
    public class EFDatabaseContext:DbContext
    {
        public EFDatabaseContext(DbContextOptions<EFDatabaseContext> options):base(options) {}
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
    }
}
