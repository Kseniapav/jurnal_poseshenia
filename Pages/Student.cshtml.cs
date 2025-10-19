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

        public async Task OnGetAsync()
        {
            Specialties = await _context.Specialtis
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Name
                })
                .ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await OnGetAsync(); // перезаполнить список при ошибке
                return Page();
            }

            _context.Students.Add(Student);
            await _context.SaveChangesAsync();
            return RedirectToPage("/Students");
        }
    }
}
