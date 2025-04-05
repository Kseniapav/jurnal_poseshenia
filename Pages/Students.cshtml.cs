using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using jurnal_poseshenia.Data;
using jurnal_poseshenia.Model;

namespace jurnal_poseshenia.Pages
{
    public class StudentsModel : PageModel
    {
        private readonly jurnal_poseshenia.Data.ApplicationDbContext _context;

        public StudentsModel(jurnal_poseshenia.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["SpecialtiId"] = new SelectList(_context.Specialtis, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Students.Add(Student);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
