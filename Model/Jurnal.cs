using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace jurnal_poseshenia.Model
{
    public class Jurnal

    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Укажите наименование специальности")]
        [StringLength(100, ErrorMessage = "Название предмета не может быть длиннее 100 символов")]
        public string Specialty { get; set; } = string.Empty;

        [Required(ErrorMessage = "Выберите студента")]
        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }    // <-- внешний ключ

        public Student? Student { get; set; } // <-- навигационное свойство

        [Required(ErrorMessage = "Укажите дату посещения")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата посещения")]
        public DateTime VisitDate { get; set; }

        // Проверка, чтобы не выбирали воскресенье
        public ValidationResult? ValidateVisitDate(ValidationContext validationContext)
        {
            if (VisitDate.DayOfWeek == DayOfWeek.Sunday)
            {
                return new ValidationResult("Воскресенье не учебный день, укажите другую дату");
            }
            return ValidationResult.Success;
        }
    }
}
