using Microsoft.EntityFrameworkCore;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace MobileShop.Data.Data
{
    public class MobileShopContext : DbContext
    {
        public MobileShopContext(DbContextOptions<MobileShopContext> options)
            : base(options)
        {
        }

        public DbSet<Shop.Models.Phone> Phone { get; set; }
        public DbSet<Shop.Models.User> User { get; set; }
        public DbSet<Shop.Models.Brand> Brand { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Phone>()
                .Property(p => p.Status)
                .HasDefaultValue(true);
            modelBuilder.Entity<Brand>()
                .Property(p => p.Status)
                .HasDefaultValue(true);

            modelBuilder.Entity<Phone>()
             .HasOne(p => p.PhoneBrand)
             .WithMany(b => b.Phones)
             .HasForeignKey(p => p.BrandID);

        }
    }
}
