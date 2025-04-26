using jurnal_poseshenia.Data;
using jurnal_poseshenia.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace jurnal_poseshenia.Pages
{
    public class JurnalsModel : PageModel
    {
        public JurnalsModel(ApplicationDbContext context)
        {
            _context = context;
        }
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public required Jurnal Jurnal { get; set; }

        public void OnGet(int id)
        {
            if (id > 0)
            {
                Jurnal = _context.Jurnals.FirstOrDefault(b => b.Id == id);
            }
            else
            {
                Jurnal = new Jurnal
                {
                    Specialty = "",
                    Student = new Student()
                };
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            if (Jurnal.Id == 0)
            {
                _context.Jurnals.Add(Jurnal);
            }
            else
            {
                _context.Jurnals.Update(Jurnal);
            }

            _context.SaveChanges();
            return RedirectToPage("Jurnals");
        }
    }
}
