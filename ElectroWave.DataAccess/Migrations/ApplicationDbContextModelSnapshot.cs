﻿// <auto-generated />
using System;
using ElectroWave.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ElectroWave.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ElectroWave.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 5,
                            Name = "Phones"
                        });
                });

            modelBuilder.Entity("ElectroWave.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2500)
                        .HasColumnType("nvarchar(2500)");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "Latest iPhone model with A15 chip, 128GB storage, and 5G connectivity.",
                            ImageURL = "",
                            Name = "iPhone 14",
                            Price = 999.99m
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Description = "Flagship smartphone from Samsung with 256GB storage and high-end performance.",
                            ImageURL = "",
                            Name = "Samsung Galaxy S23",
                            Price = 799.99m
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Description = "Lightweight and powerful laptop with the M2 chip, 512GB SSD, and 16GB RAM.",
                            ImageURL = "",
                            Name = "MacBook Air M2",
                            Price = 1299.99m
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            Description = "Industry-leading noise canceling headphones with 30-hour battery life.",
                            ImageURL = "",
                            Name = "Sony WH-1000XM5",
                            Price = 349.99m
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 1,
                            Description = "Cordless vacuum cleaner with powerful suction and up to 60 minutes of run time.",
                            ImageURL = "",
                            Name = "Dyson V11 Vacuum Cleaner",
                            Price = 599.99m
                        });
                });

            modelBuilder.Entity("ElectroWave.Models.Product", b =>
                {
                    b.HasOne("ElectroWave.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ElectroWave.Models.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
