using System.ComponentModel.DataAnnotations;

namespace Selhoz.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Введите email")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; } = string.Empty;
    }
}