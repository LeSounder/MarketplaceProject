using System.ComponentModel.DataAnnotations;


namespace MarketplaceProject.Domain.ViewModels.User
{
    public class UserViewModel
    {
        [Display(Name = "Id")]
        public long Id { get; set; }

        [Required(ErrorMessage = "Укажите роль")]
        [Display(Name = "Роль")]
        public string? Role { get; set; }

        [Required(ErrorMessage = "Укажите логин")]
        [Display(Name = "Логин")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Укажите email")]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Укажите пароль")]
        [Display(Name = "Пароль")]
        public string? Password { get; set; }
    }
}
