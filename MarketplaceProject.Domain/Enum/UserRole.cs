using System.ComponentModel.DataAnnotations;

namespace MarketplaceProject.Domain.Enum
{
    public enum UserRole
    {
        [Display(Name = "Пользователь")]
        User = 0,
        [Display(Name = "Модератор")]
        Moderator = 1,
        [Display(Name = "Администратор")]
        Admin = 2,
    }
}
