namespace TennisTournament.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.BaseModel;
    public abstract class BaseModel<TKey> 
    {
        [Key]
        public TKey Id { get; init; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }
    }
}
