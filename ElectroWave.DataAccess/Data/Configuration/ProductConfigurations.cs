using ElectroWave.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ElectroWave.DataAccess.Data.Configuration
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
           .Property(p => p.Price)
           .HasColumnType("decimal(18,2)");

            builder
            .Property(p => p.OriginalPrice)
            .HasColumnType("decimal(18,2)");

        }
    }
}
