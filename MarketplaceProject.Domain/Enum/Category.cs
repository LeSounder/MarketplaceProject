using System.ComponentModel.DataAnnotations;

namespace MarketplaceProject.Domain.Enum
{
    public enum Category
    {
        [Display(Name = "Электроника")]
        Electronics = 0,
        [Display(Name = "Товары для дома")]
        Household = 1,
        [Display(Name = "Одежда, обувь и аксессуары")]
        Clothes = 2,
        [Display(Name = "Компьютерная техника")]
        Computers = 3,
        [Display(Name = "Аптека")]
        Pharmacy = 4,
        [Display(Name = "Продукты")]
        FoodSection = 5
    }
}
