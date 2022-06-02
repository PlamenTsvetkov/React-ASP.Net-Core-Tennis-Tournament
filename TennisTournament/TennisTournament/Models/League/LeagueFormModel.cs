namespace TennisTournament.Models.League
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.BaseModel;
    public class LeagueFormModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = "Name {0} must be between {2} and {1} characters long")]
        public string Name { get; set; }

        [Range(1, 4)]
        [Display(Name = "Surface")]
        public int SurfaceId { get; set; }

        [Range(6, 7)]
        [Display(Name = "Tournament Type")]
        public int TournamentTypeId { get; set; }

    }
}
