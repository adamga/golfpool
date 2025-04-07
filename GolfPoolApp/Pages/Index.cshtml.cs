using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace GolfPoolApp.Pages;

public class IndexModel : PageModel
{
    public IActionResult OnGet()
    {
        var loggedInUser = HttpContext.Session.GetString("LoggedInUser");
        if (string.IsNullOrEmpty(loggedInUser))
        {
            return RedirectToPage("/Login");
        }

        return Page();
    }
}
