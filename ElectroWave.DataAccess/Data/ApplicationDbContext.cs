using ElectroWave.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ElectroWave.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
       
            modelBuilder.Entity<Product>()
            .Property(p => p.Price)
            .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Product>()
            .Property(p => p.OriginalPrice)
            .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Mobile Phones", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Laptops", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Televisions", DisplayOrder = 3 },
                new Category { Id = 4, Name = "Smartwatches", DisplayOrder = 4 },
                new Category { Id = 5, Name = "Tablets", DisplayOrder = 5 },
                new Category { Id = 6, Name = "Headphones", DisplayOrder = 6 }
            );
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
