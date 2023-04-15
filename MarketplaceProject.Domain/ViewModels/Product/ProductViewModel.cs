

using MarketplaceProject.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace MarketplaceProject.Domain.ViewModels.Product
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        public Category Category { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
    }
}
