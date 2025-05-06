using jurnal_poseshenia.Data;
using jurnal_poseshenia.Model.AuthApp;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace jurnal_poseshenia.Pages.Account
{
    [Authorize(Roles = "Admin")]
    public class RegisterModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public RegisterModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Model.AuthApp.RegisterModel Input { get; set; }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            bool isFirstUser = !_context.AuthUsers.Any();

            var user = _context.AuthUsers.FirstOrDefault(u => u.Email == Input.Email);

            if (user == null)
            {
                _context.AuthUsers.Add(new AuthUser { Email = Input.Email, Password = Input.Password, Role = isFirstUser ? "Admin" : "User" });
                await _context.SaveChangesAsync();

                await Authenticate(Input.Email, Input.Role);
                return RedirectToPage("/Index");
            }

            ModelState.AddModelError(string.Empty, "????? ???????????? ??? ??????????");
            return Page();
        }

        private async Task Authenticate(string email, string role)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, email),
                 new Claim(ClaimsIdentity.DefaultRoleClaimType, role)

            };
            var identity = new ClaimsIdentity(claims, "ApplicationCookie");
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }
    }
}
