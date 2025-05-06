using System.ComponentModel.DataAnnotations;

namespace jurnal_poseshenia.Model.AuthApp
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Пустое поле. Укажите Email.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Пустое поле. Укажите пароль.")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Подтверждение введено неверно")]
        public string? ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Пустое поле. Укажите Email.")]
        public string Role { get; set; } = "User"; // По умолчанию обычный пользователь

    }
}
