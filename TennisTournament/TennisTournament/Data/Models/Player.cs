namespace TennisTournament.Data.Models
{
    public class Player : BaseModel<int>
    {
        public Player()
        {
            this.LeaguePlayers = new HashSet<LeaguePlayers>();
        }

        public virtual ICollection<LeaguePlayers> LeaguePlayers { get; init; }
    }
}
