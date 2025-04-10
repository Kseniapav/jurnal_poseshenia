using jurnal_poseshenia.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace jurnal_poseshenia.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //Database.Migrate(); // Автоматически применяет миграции и создаёт базу, если её нет
        }
        public DbSet<Student> Students { get; set; }//таблица Students, содержащая данные о студентах.
        public DbSet<Jurnal> Jurnals { get; set; } // таблица Jurnal, содержащая данные о специальностях и студентах на них
        public DbSet <Specialti> Specialtis { get; set; } //таблица Specialtis, содержащая информацию о специальностях

    }
}
