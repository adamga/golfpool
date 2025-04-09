using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GolfPoolApp.Data;
using Microsoft.EntityFrameworkCore;

namespace GolfPoolApp.Pages.TournamentPlayers
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Player).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(Player.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("Index");
        }

        private bool PlayerExists(int id)
        {
            return _context.TournamentPlayers.Any(e => e.Id == id);
        }
    }
}