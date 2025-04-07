using Microsoft.EntityFrameworkCore;

namespace GolfPoolApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserPick> UserPicks { get; set; }
        public DbSet<TournamentPlayer> TournamentPlayers { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
    }

    public class UserPick
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TournamentPlayerId { get; set; }
    }

    public class TournamentPlayer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
    }
}