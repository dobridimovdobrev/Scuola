using System.ComponentModel.DataAnnotations;

namespace Scuola.Models.Dto.Request
{
    public class UpdateStudenteRequest
    {
        [Required]
        public Guid Id { get; set; }

        [StringLength(50)]
        public string? Nome { get; set; }

        [StringLength(50)]
        public string? Cognome { get; set; }

        [StringLength(70)]
        [EmailAddress]
        public string? Email { get; set; }

        [StringLength(16, MinimumLength = 16)]
        public string? CodiceFiscale { get; set; }

        public DateOnly? DataDiNascita { get; set; }
    }
}