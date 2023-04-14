using MarketplaceProject.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace MarketplaceProject.Domain.Entities
{
    public class User
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public UserRole Role { get; set; }


    }
}
