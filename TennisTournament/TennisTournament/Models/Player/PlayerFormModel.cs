namespace TennisTournament.Models.Player
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.BaseModel;
    public class PlayerFormModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = "Name {0} must be between {2} and {1} characters long")]
        public string Name { get; set; }
    }
}
