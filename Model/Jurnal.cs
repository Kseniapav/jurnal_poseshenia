using System.ComponentModel.DataAnnotations;

namespace jurnal_poseshenia.Model
{
    public class Jurnal

    {
        public int Id { get; set; }

        [Required (ErrorMessage = "Укажите наименование специальности")]
        [StringLength (100, ErrorMessage = "Название предмета не может быть длиннее 100 символов ")]
        public required string Specialty { get; set; }

        public int StudentId { get; set; }
        public required Student Student { get; set; }

        [Required(ErrorMessage = "Укажите дату посещения")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата посещения")]
        public DateTime VisitDate { get; set; }
        public ValidationResult ValidateVisitDate(ValidationContext validationContext)
        {
            if (VisitDate.DayOfWeek == DayOfWeek.Sunday)
            {
                return new ValidationResult("Воскресенье не учебный день, укажите другую дату");
            }
            return ValidationResult.Success;
        }

    }
}
