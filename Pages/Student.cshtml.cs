using jurnal_poseshenia.Data;
using jurnal_poseshenia.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace jurnal_poseshenia.Pages
{
    public class StudentModel : PageModel
    {
        public StudentModel(ApplicationDbContext context)
        {
            _context = context;
        }
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public required Student Student { get; set; } = new Student();
        public List<SelectListItem> Specialties { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Specialties = await _context.Specialtis
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Name
                })
                .ToListAsync();

            if (id == null || id == 0)
            {
                Student = new Student();
                return Page();
            }

            Student = await _context.Students.FindAsync(id);

            if (Student == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Specialties = await _context.Specialtis
                    .Select(s => new SelectListItem
                    {
                        Value = s.Id.ToString(),
                        Text = s.Name
                    })
                    .ToListAsync();
                return Page();
            }

            if (Student.Id == 0)
            {
                // Добавление нового студента
                _context.Students.Add(Student);
            }
            else
            {
                // Обновление существующего студента
                _context.Students.Update(Student);
            }

            await _context.SaveChangesAsync();
            return RedirectToPage("/Students");
        }
    }
}
