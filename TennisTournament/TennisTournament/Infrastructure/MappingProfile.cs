namespace TennisTournament.Infrastructure
{
    using AutoMapper;
    using TennisTournament.Data.Models;
    using TennisTournament.Models.League;
    using TennisTournament.Models.Player;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<League, AllLeaguesQueryModel>();

            this.CreateMap<Player, AllPlayersQueryModel>();

        }
    }
}
