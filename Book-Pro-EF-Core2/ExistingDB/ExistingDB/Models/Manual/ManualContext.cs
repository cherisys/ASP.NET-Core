using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExistingDB.Models.Manual
{
    public class ManualContext:DbContext
    {
        public ManualContext(DbContextOptions<ManualContext> options) : base(options) { }
        public DbSet<Shoe> Shoes { get; set; }
        public DbSet<Style> ShoeStyles { get; set; }
        public DbSet<ShoeWidth> ShoeWidths { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //overriding Data Modeling Conventions using Fluent API
            modelBuilder.Entity<ShoeWidth>().ToTable("Fittings");
            modelBuilder.Entity<ShoeWidth>().HasKey(t => t.UniqueIdent);
            modelBuilder.Entity<ShoeWidth>().Property(t => t.UniqueIdent).HasColumnName("Id");
            modelBuilder.Entity<ShoeWidth>().Property(t => t.WidthName).HasColumnName("Name");

            //overriding the Relationship Conventions using Fluent API
            modelBuilder.Entity<Shoe>().Property(s => s.WidthId).HasColumnName("FittingId");
            modelBuilder.Entity<Shoe>().HasOne(s => s.Width).WithMany(w => w.Products).HasForeignKey(s => s.WidthId).IsRequired(true);
        }
    }
}
