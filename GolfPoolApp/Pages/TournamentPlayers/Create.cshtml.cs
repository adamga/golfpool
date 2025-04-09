using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GolfPoolApp.Data;

namespace GolfPoolApp.Pages.TournamentPlayers
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TournamentPlayer Player { get; set; } = new();

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TournamentPlayers.Add(Player);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}