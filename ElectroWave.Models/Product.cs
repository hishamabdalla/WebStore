﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroWave.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Product Name")]
        public string Name { get; set; }

        [Range(1, 100000, ErrorMessage = "Original price must be between 1 and 100,000.")]
        [DisplayName("Original Price")]
        public double OriginalPrice { get; set; }  

        [Range(1, 100000, ErrorMessage = "Price must be between 1 and 100,000.")]
        [DisplayName("Price After Discount")]
        public double Price { get; set; }

        [MaxLength(2500, ErrorMessage = "Description can't be longer than 3000 characters.")]
        public string Description { get; set; }

        [ValidateNever]
        public string ImageURL { get; set; }

        [DisplayName("Category")]

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }

        public virtual Category? Category { get; set; }



    }
}
