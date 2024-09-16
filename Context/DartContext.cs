using DeathDartOfGlorySeasonOne.Models;
using Microsoft.EntityFrameworkCore;

namespace DeathDartOfGlorySeasonOne.Context;

public class DartContext : DbContext
{
    public DartContext(DbContextOptions<DartContext> options) : base(options) { }

    public DbSet<Player> Players { get; set; }
    public DbSet<Match> Matches { get; set; }
    public DbSet<PlayerScore> PlayerScores { get; set; }
    public DbSet<KlockanGamePlayer> KlockanGamePlayers { get; set; }
    public DbSet<_301GamePlayer> _301GamePlayers { get; set; }
}
