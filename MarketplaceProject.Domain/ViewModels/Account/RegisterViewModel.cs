using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceProject.Domain.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Укажите имя пользователя")]
        [MaxLength(20, ErrorMessage ="Имя не должно быть больше 20 символов")]
        [MinLength(3, ErrorMessage ="Имя должно быть не меньше 3 символов")]
        public string UserName { get; set; }



        public string Email { get; set; }


        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Укажите пароль")]
        [MinLength(8, ErrorMessage ="Пароль должен содержать минимум 8 символов")]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Подтвердите пароль")]
        [Compare("Password", ErrorMessage ="Пароли не совпадают")]
        public string PasswordConfirmed { get; set; }
    }
}
