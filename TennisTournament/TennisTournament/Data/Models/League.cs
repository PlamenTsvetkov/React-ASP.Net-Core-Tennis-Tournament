namespace TennisTournament.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class League : BaseModel<int>
    {
        public League()
        {
            this.LeaguePlayers = new HashSet<LeaguePlayers>();
        }

       
        public int SurfaceId { get; set; }

        public virtual Surface Surface { get; init; }

        public int TournamentTypeId { get; set; }

        public virtual TournamentType TournamentType { get; init; }

        public virtual ICollection<LeaguePlayers> LeaguePlayers { get; init; }



    }
}
