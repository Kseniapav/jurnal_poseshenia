using System.ComponentModel.DataAnnotations;

namespace jurnal_poseshenia.Model
{
    public class Jurnal
    {
        public int Id { get; set; }

        [Required (ErrorMessage = "Укажите наименование специальности")]
        [StringLength (100, ErrorMessage = "Название предмета не может быть длиннее 100 символов ")]
        public required string Name { get; set; }

        public int StudentId { get; set; }
        public required Student Student { get; set; }

        public int SpecialtiId { get; set; }
        public required Specialti Specialti { get; set; }

    }
}
