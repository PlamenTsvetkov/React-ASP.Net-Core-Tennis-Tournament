namespace TennisTournament.Data.Models
{

    public class TournamentType : BaseModel<int>
    {
        public TournamentType()
        {
            this.Leagues = new HashSet<League>();
        }

        public virtual ICollection<League> Leagues { get; init; }
    }
}
