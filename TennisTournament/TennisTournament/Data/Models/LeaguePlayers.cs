namespace TennisTournament.Data.Models
{
    public class LeaguePlayers
    {
        public int LeagueId { get; set; }
        public virtual League League { get; init; }

        public int PlayerId { get; set; }
        public virtual Player Player { get; init; }
    }
}
