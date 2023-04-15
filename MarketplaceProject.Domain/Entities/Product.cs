using System.ComponentModel.DataAnnotations;
using MarketplaceProject.Domain.Enum;

namespace MarketplaceProject.Domain.Entities
{
    public class Product
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        public Category Category { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string ImgPath { get; set; }
        

    }
}
