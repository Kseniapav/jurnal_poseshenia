using jurnal_poseshenia.Data;
using jurnal_poseshenia.Model.AuthApp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace jurnal_poseshenia.Pages.Account
{
    [Authorize(Roles = "Admin")]
    public class ProfilesModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public ProfilesModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<AuthUser> Users { get; set; } = new();

        public void OnGet()
        {
            Users = _context.AuthUsers.ToList();
        }
    }
}
