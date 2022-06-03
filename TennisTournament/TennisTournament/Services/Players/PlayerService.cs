namespace TennisTournament.Services.Players
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using TennisTournament.Data;
    using TennisTournament.Data.Models;

    public class PlayerService : IPlayerService
    {
        private readonly TournamentDbContext db;
        private readonly IMapper mapper;
        public PlayerService(TournamentDbContext db,
                                    IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public Player Create(string name)
        {
            var playerDate = this
               .db
               .Players
               .FirstOrDefault(l => l.Name == name);

            if (playerDate != null)
            {
                return playerDate;
            }

            playerDate = new Player
            {
                Name = name
            };

            this.db.Players.Add(playerDate);
            this.db.SaveChanges();

            return playerDate;
        }

        public bool Delete(int id)
        {
            var player = this.db.Players.FirstOrDefault(l => l.Id == id);

            if (player == null)
            {
                return false;
            }

            this.db.Players.Remove(player);

             this.db.SaveChanges();
            return true;
        }

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            IQueryable<Player> query =
                                   this.db.Players
                                   .OrderBy(x => x.Name);

            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.ProjectTo<T>(this.mapper.ConfigurationProvider).ToList();
        }

        public bool Update(int id, string name)
        {
            var player = this.db.Leagues.FirstOrDefault(p => p.Id == id);

            if (player == null)
            {
                return false;
            }

            player.Name = name;

            this.db.SaveChangesAsync();

            return true;
        }


    }
}
