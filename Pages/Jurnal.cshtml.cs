using jurnal_poseshenia.Data;
using jurnal_poseshenia.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace jurnal_poseshenia.Pages
{
    public class JurnalsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public JurnalsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Jurnal Jurnal { get; set; } = new();

        public List<SelectListItem> StudentList { get; set; } = new();

        public async Task OnGetAsync(int id)
        {
            StudentList = await _context.Students
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = $"{s.Surname} {s.Name} {s.Partomymic}"
                })
                .ToListAsync();

            if (id > 0)
            {
                Jurnal = await _context.Jurnals.FirstOrDefaultAsync(b => b.Id == id) ?? new Jurnal();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await OnGetAsync(Jurnal.Id); // чтобы список студентов не потерялся
                return Page();
            }

            if (Jurnal.Id == 0)
                _context.Jurnals.Add(Jurnal);
            else
                _context.Jurnals.Update(Jurnal);

            await _context.SaveChangesAsync();
            return RedirectToPage("/Jurnals");
        }
    }
}
