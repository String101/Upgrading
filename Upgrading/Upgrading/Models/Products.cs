using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Upgrading.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [NotMapped]
        public FormFile? Image { get; set; }
        [Required]
        public string ImageUrl { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Product Type")]
        public string ProductType { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Product Price")]
        public double ProductPrice { get; set; }
    }
}
