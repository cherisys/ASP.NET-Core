using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStoreNew.Models
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasIndex(p => p.Name);
            modelBuilder.Entity<Product>().HasIndex(p => p.PurchasePrice);
            modelBuilder.Entity<Product>().HasIndex(p => p.RetailPrice);
            modelBuilder.Entity<Category>().HasIndex(p => p.Name);
            modelBuilder.Entity<Category>().HasIndex(p => p.Description);
        }
    }
}
