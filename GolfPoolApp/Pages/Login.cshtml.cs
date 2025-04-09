using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using GolfPoolApp.Data;

namespace GolfPoolApp.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public LoginModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        [Required]
        public string Username { get; set; } = string.Empty;

        [BindProperty]
        [Required]
        public string Password { get; set; } = string.Empty;

        public string ErrorMessage { get; set; } = string.Empty;

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Simulate user authentication logic
            var user = _context.Users.FirstOrDefault(u => u.Username == Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(Password, user.PasswordHash))
            {
                ErrorMessage = "Invalid username or password.";
                return Page();
            }

            // Set session for logged-in user
            HttpContext.Session.SetString("LoggedInUser", Username);

            // Store the user's role or admin status in the session
            bool isAdmin = (Username == "admin"); // Example check for admin user
            HttpContext.Session.SetString("IsAdmin", isAdmin.ToString());

            return RedirectToPage("/Index");
        }
    }
}
