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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                 new Category { Id = 1, Name = "Mobile Phones", DisplayOrder = 1 },
                 new Category { Id = 2, Name = "Laptops", DisplayOrder = 2 },
                 new Category { Id = 3, Name = "Televisions", DisplayOrder = 3 },
                 new Category { Id = 4, Name = "Smartwatches", DisplayOrder = 4 },
                 new Category { Id = 5, Name = "Tablets", DisplayOrder = 5 },
                 new Category { Id = 6, Name = "Headphones", DisplayOrder = 6 }
             );
        }
    }
}
