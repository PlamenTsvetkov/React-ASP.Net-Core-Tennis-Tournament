namespace TennisTournament.Data
{
    using Microsoft.EntityFrameworkCore;
    using TennisTournament.Data.Models;

    public class TournamentDbContext  : DbContext
    {
        public TournamentDbContext()
        {
        }

        public TournamentDbContext(DbContextOptions options)
           : base(options)
        {
        }

        public DbSet<League> Leagues { get; init; }
        public DbSet<Player> Players { get; init; }
        public DbSet<Surface> Surfaces { get; init; }
        public DbSet<TournamentType> TournamentTypes { get; init; }
        public DbSet<LeaguePlayers> LeaguesPlayers { get; init; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=TennisTournament;Integrated Security=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<LeaguePlayers>()
                    .HasKey(lp => new { lp.LeagueId, lp.PlayerId });

            builder.Entity<LeaguePlayers>()
                .HasOne(kc => kc.League)
                .WithMany(k => k.LeaguePlayers)
                .HasForeignKey(kc => kc.LeagueId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<LeaguePlayers>()
                .HasOne(kc => kc.Player)
                .WithMany(c => c.LeaguePlayers)
                .HasForeignKey(kc => kc.PlayerId)
                .OnDelete(DeleteBehavior.Restrict);
            base.OnModelCreating(builder);
        }
    }
}
