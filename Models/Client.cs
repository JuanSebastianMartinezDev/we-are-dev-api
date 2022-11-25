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

        [ForeignKey("TypeClientId")]
        public int TypeClientId { get; set; }
        public virtual TypeClient TypeClient { get; set; }

        [ForeignKey("CountryId")]
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        [ForeignKey("SectorId")]
        public int SectorId { get; set; }
        public virtual Sector Sector { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public List<ClientAnnotation> Annotations { get; set; }
        
        public List<ClientTag> Tags { get; set; }

    }
}
