namespace TennisTournament.Models.League
{
    public class AllLeaguesQueryModel
    {
        public int Id { get; init; }

        public string Name { get; set; }

        public string SurfaceName { get; set; }

        public string TournamentTypeName { get; set; }
    }
}
