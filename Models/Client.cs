using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeAreDevApi.Models
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public string? Description { get; set; }

        public string? UrlImage { get; set; }

        public int State { get; set; } = 1;

        public int Phone { get; set; }

        public int? Phone2 { get; set; }

        public string? City { get; set; }

        public string? Direction { get; set; }

        public int TypeClientId { get; set; }

        [ForeignKey("TypeClientId")]
        public virtual TypeClient TypeClient { get; set; }

        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }
        public DateOnly? CreatedAt { get; set; }
        public DateOnly? UpdatedAt { get; set; }
    }
}
