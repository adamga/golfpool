using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GolfPoolApp.Data;

namespace GolfPoolApp.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<TournamentPlayer> Players { get; set; } = new();

        [BindProperty]
        public TournamentPlayer Player { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            var loggedInUser = HttpContext.Session.GetString("LoggedInUser");
            if (string.IsNullOrEmpty(loggedInUser))
            {
                return RedirectToPage("/Login");
            }

            Players = await _context.TournamentPlayers.ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAddAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TournamentPlayers.Add(Player);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var player = await _context.TournamentPlayers.FindAsync(id);

            if (player == null)
            {
                return NotFound();
            }

            _context.TournamentPlayers.Remove(player);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}
