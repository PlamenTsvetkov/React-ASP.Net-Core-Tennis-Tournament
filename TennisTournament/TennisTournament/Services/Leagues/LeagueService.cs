namespace TennisTournament.Services.Leagues
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TennisTournament.Data;
    using TennisTournament.Data.Models;

    public class LeagueService : ILeagueService
    {
        private readonly TournamentDbContext db;
        private readonly IMapper mapper;
        public LeagueService(TournamentDbContext db,
                                    IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public League Create(string name, int surfaceId, int tournamentTypeId)
        {
            var leagueDate = this
               .db
               .Leagues
               .FirstOrDefault(l => l.Name == name && l.SurfaceId == surfaceId && l.TournamentTypeId == tournamentTypeId);

            if (leagueDate != null)
            {
                return leagueDate;
            }

            leagueDate = new League
            {
                Name = name,
                SurfaceId = surfaceId,
                TournamentTypeId = tournamentTypeId
            };

            this.db.Leagues.Add(leagueDate);
            this.db.SaveChanges();

            return leagueDate;
        }

        public async  Task DeleteAsync(int id)
        {
            var league = this.db.Leagues.FirstOrDefault(l => l.Id == id);

            if (league == null)
            {
                return;
            }

            this.db.Leagues.Remove(league);

            await this.db.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            IQueryable<League> query =
                                   this.db.Leagues
                                   .OrderBy(x => x.Name);

            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.ProjectTo<T>(this.mapper.ConfigurationProvider).ToList();
        }

        public async Task UpdateAsync(int id, string name, int surfaceId, int tournamentTypeId)
        {
            var league = this.db.Leagues.FirstOrDefault(l => l.Id == id);

            if (league == null)
            {
                return;
            }

            league.Name = name;

            league.SurfaceId = surfaceId;

            league.TournamentTypeId=tournamentTypeId;

            await this.db.SaveChangesAsync();
        }
    }
}
