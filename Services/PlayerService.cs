using DeathDartOfGlorySeasonOne.Context;
using DeathDartOfGlorySeasonOne.Models;
using Microsoft.EntityFrameworkCore;

namespace DeathDartOfGlorySeasonOne.Services
{
    public class PlayerService
    {
        private readonly DartContext _context;

        public PlayerService(DartContext context)
        {
            _context = context;
        }

        // Metod för att få alla spelare med deras totalpoäng
        public async Task<List<PlayerWithTotalScore>> GetPlayersWithTotalScoresAsync()
        {
            var matches = await _context.Matches.Include(m => m.PlayerScores).ToListAsync();

            // Hämta alla spelare från databasen
            var players = await _context.Players.ToListAsync();

            // Beräkna totalpoängen för varje spelare
            var playerScores = matches
                .SelectMany(m => m.PlayerScores)
                .GroupBy(ps => ps.PlayerId)
                .Select(g => new
                {
                    PlayerId = g.Key,
                    TotalScore = g.Sum(ps => ps.Score ?? 0) // Summera och hantera null
                })
                .ToList();

            // Skapa en lista med PlayerWithTotalScore genom att matcha spelare med deras totalpoäng
            var result = players.Select(p => new PlayerWithTotalScore
            {
                Player = p,
                TotalScore = playerScores.FirstOrDefault(ps => ps.PlayerId == p.Id)?.TotalScore ?? 0
            }).ToList();

            return result;
        }




        // Hämta alla spelare
        public async Task<List<Player>> GetAllPlayersAsync()
        {
            return await _context.Players.ToListAsync();
        }

        // Hämta en specifik spelare
        public async Task<Player?> GetPlayerByIdAsync(int id)
        {
            return await _context.Players.FindAsync(id);
        }

        // Lägg till en ny spelare
        public async Task AddPlayerAsync(Player player)
        {
            _context.Players.Add(player);
            await _context.SaveChangesAsync();
        }

        // Ta bort en spelare
        public async Task DeletePlayerAsync(int id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player != null)
            {
                _context.Players.Remove(player);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddMatchAsync(Match match)
        {
            _context.Matches.Add(match);
            await _context.SaveChangesAsync();
        }
    }

    // DTO för att visa spelare med totalpoäng
    public class PlayerWithTotalScore
    {
        public Player Player { get; set; }
        public int TotalScore { get; set; }
    }

    public class PlayerScore
    {
        public int PlayerId { get; set; }
        public int Score { get; set; }
    }
}
