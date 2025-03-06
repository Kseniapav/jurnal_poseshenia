using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace jurnal_poseshenia.Pages
{
    public class StudentModel(AplicationDbContext context) : PageModel
    {
        private readonly ApplicationDbContext _context = context;
        public void OnGet()
        {

        }
    }
}
