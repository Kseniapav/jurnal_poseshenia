using System.ComponentModel.DataAnnotations;

namespace jurnal_poseshenia.Model
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Укажите фамилию студента.")]
        [StringLength(100, ErrorMessage = "Фамилия студента не может быть длиннее 100 символов")]
        public required string Surname { get; set; }

        [Required(ErrorMessage = "Укажите имя студента.")]
        [StringLength(100, ErrorMessage = "Имя студента не может быть длиннее 100 символов")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Укажите отчество студента.")]
        [StringLength(100, ErrorMessage = "Отчество студента не может быть длиннее 100 символов")]
        public required string Partomymic { get; set; }


        public required int SpecialtiId { get; set; }
        public required Specialti Specialti { get; set; }

    }
}
