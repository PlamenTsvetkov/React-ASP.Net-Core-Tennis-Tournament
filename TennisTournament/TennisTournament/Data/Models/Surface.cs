namespace TennisTournament.Data.Models
{

    public class Surface : BaseModel<int>
    {
        public Surface()
        {
            this.Leagues = new HashSet<League>();
        }

        public virtual ICollection<League> Leagues { get; init; }
    }
}
