namespace TennisTournament.Infrastructure
{
    using Microsoft.EntityFrameworkCore;

    using TennisTournament.Data;
    using TennisTournament.Data.Models;

    public static class ApplicationBuilderExtensions
    {

        public static IApplicationBuilder PrepareDatabase(
            this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;

            SeedTournamentType(services);

            SeedSurface(services);

            SeedLeague(services);

            MigrateDatabase(services);

            return app;
        }
        private static void MigrateDatabase(IServiceProvider services)
        {
            var data = services.GetRequiredService<TournamentDbContext>();

            data.Database.Migrate();
        }
        private static void SeedTournamentType(IServiceProvider services)
        {
            var data = services.GetRequiredService<TournamentDbContext>();

            if (data.TournamentTypes.Any())
            {
                return;
            }

            var tournamentTypes = new List<string>
            {
                "Round Robin",
                "Bracket",

            };
            foreach (var tournamentType in tournamentTypes)
            {
                data.TournamentTypes.AddAsync(new TournamentType
                {
                    Name = tournamentType,
                });
            }

            data.SaveChanges();
        }
        private static void SeedSurface(IServiceProvider services)
        {
            var data = services.GetRequiredService<TournamentDbContext>();

            if (data.Surfaces.Any())
            {
                return;
            }

            var surfaces = new List<string>
            {
                "Clay",
                "Omni",
                "Hard",
                "Floor",

            };
            foreach (var surface in surfaces)
            {
                data.Surfaces.AddAsync(new Surface
                {
                    Name = surface,
                });
            }

            data.SaveChanges();
        }

        private static void SeedLeague(IServiceProvider services)
        {
            var data = services.GetRequiredService<TournamentDbContext>();

            if (data.Leagues.Any())
            {
                return;
            }

           
                data.Leagues.AddAsync(new League
                {
                    Name = "Cvetkov Cup",
                    SurfaceId=1,
                    TournamentTypeId=6
                });

            data.SaveChanges();
        }
    }
}
