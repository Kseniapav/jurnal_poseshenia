using jurnal_poseshenia.Data;
using jurnal_poseshenia.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace jurnal_poseshenia.Pages
{
    public class JurnalModel(ApplicationDbContext context) : PageModel
    {
        private readonly ApplicationDbContext _context = context;

        public IList<Jurnal> Jurnals { get; set; } // Используем существующую модель Jurnal

        public async Task OnGetAsync()
        {
            Jurnals = await _context.Jurnals.ToListAsync(); // Предполагая, что в DbContext есть DbSet<Jurnal>
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var journal = await _context.Jurnals.FindAsync(id);
            if (journal != null)
            {
                _context.Jurnals.Remove(journal);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }
    }
}
