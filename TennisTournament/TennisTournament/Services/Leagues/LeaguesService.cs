namespace TennisTournament.Services.Leagues
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using System.Collections.Generic;
    using TennisTournament.Data;
    using TennisTournament.Data.Models;

    public class LeaguesService : ILeaguesService
    {
        private readonly TournamentDbContext db;
        private readonly IMapper mapper;
        public LeaguesService(TournamentDbContext db,
                                    IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
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
    }
}
