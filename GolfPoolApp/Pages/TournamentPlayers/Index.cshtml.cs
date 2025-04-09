using Microsoft.AspNetCore.Mvc.RazorPages;
using GolfPoolApp.Data;
using Microsoft.EntityFrameworkCore;

namespace GolfPoolApp.Pages.TournamentPlayers
{
    public class TournamentPlayersModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public TournamentPlayersModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<TournamentPlayer> Players { get; set; } = new();

        public async Task OnGetAsync()
        {
            Players = await _context.TournamentPlayers.ToListAsync();
        }
    }
}