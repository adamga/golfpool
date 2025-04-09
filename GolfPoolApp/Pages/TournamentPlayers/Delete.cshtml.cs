using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GolfPoolApp.Data;

namespace GolfPoolApp.Pages.TournamentPlayers
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TournamentPlayer Player { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Player = await _context.TournamentPlayers.FindAsync(id);

            if (Player == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var player = await _context.TournamentPlayers.FindAsync(id);

            if (player == null)
            {
                return NotFound();
            }

            _context.TournamentPlayers.Remove(player);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}