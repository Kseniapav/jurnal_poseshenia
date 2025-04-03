using System.ComponentModel.DataAnnotations;

namespace jurnal_poseshenia.Model
{
    public class Specialti
    {
        public int Id {  get; set; }

        [Required(ErrorMessage = "Требуется название.")]
        [StringLength(100, ErrorMessage = "Название не может быть длиннее 100 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Укажите срок обучения.")]
        [RegularExpression(@"^(34/46)$", ErrorMessage = "Укажите 34 или 46 в поле 'Срок обучения'")] //срок указан в месяцах
        public required int TermОfStudy { get; set; }
    }
}
