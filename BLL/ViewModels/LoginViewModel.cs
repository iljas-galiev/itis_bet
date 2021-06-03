using System.ComponentModel.DataAnnotations;


namespace BLL.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Электронная почта")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        public bool Remember { get; set; }
    }
}
