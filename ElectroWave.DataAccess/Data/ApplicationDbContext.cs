﻿using ElectroWave.Models;
using Microsoft.EntityFrameworkCore;

namespace ElectroWave.DataAccess.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                  new Product
                  {
                      Id = 1,
                      Name = "iPhone 14",
                      Price = 999.99m,
                      Description = "Latest iPhone model with A15 chip, 128GB storage, and 5G connectivity."
                  },
                  new Product
                  {
                      Id = 2,
                      Name = "Samsung Galaxy S23",
                      Price = 799.99m,
                      Description = "Flagship smartphone from Samsung with 256GB storage and high-end performance."
                  },
                  new Product
                  {
                      Id = 3,
                      Name = "MacBook Air M2",
                      Price = 1299.99m,
                      Description = "Lightweight and powerful laptop with the M2 chip, 512GB SSD, and 16GB RAM."
                  },
                  new Product
                  {
                      Id = 4,
                      Name = "Sony WH-1000XM5",
                      Price = 349.99m,
                      Description = "Industry-leading noise canceling headphones with 30-hour battery life."
                  },
                  new Product
                  {
                      Id = 5,
                      Name = "Dyson V11 Vacuum Cleaner",
                      Price = 599.99m,
                      Description = "Cordless vacuum cleaner with powerful suction and up to 60 minutes of run time."
                  }
            );
        
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
