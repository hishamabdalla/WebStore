using System.ComponentModel.DataAnnotations;

namespace WebStoreRazor_Temp.Model
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Category Name")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Display(Name = "Display Order")]
        [Range(1, 100)]
        public int DisplayOrder { get; set; }

    }
}

