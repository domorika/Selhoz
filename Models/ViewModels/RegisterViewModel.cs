using System.ComponentModel.DataAnnotations;

namespace Selhoz.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Введите email")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Введите пароль")]
        [StringLength(100, MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [Display(Name = "Подтвердите пароль")]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Display(Name = "Роль")]
        public string Role { get; set; } = string.Empty;
    }
}