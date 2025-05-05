using System.ComponentModel.DataAnnotations;

namespace jurnal_poseshenia.Model.AuthApp
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Пустое поле. Укажите Email.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Пустое поле. Укажите пароль")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
