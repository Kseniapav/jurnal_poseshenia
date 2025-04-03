using jurnal_poseshenia.Data;
using jurnal_poseshenia.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
        public required Student Student { get; set; }

        public void OnGet(int id)
        {
            if (id > 0)
            {
                Student = _context.Students.FirstOrDefault(b => b.Id == id);
            }
            else
            {
                Student = new Student();
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Student.Id == 0)
            {
                _context.Students.Add(Student);
            }
            else
            {
                _context.Students.Update(Student);
            }

            _context.SaveChanges();
            return RedirectToPage("Students");
        }
    }
}
