﻿using System.ComponentModel.DataAnnotations;

namespace ElectroWave.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Category Name")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Display(Name ="Display Order")]
        [Range(1,100)]
        public int DisplayOrder { get; set; }

        public virtual ICollection<Product>? Products { get; set; }

    }
}
