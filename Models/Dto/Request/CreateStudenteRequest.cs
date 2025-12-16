using System.ComponentModel.DataAnnotations;

namespace Scuola.Models.Dto.Request
{
    public class CreateStudenteRequest
    {
        //studente

        [Required(ErrorMessage = "Nome obbligatorio")]
        [StringLength(50)]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Cognome obbligatorio")]
        [StringLength(50)]
        public string Cognome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email obbligatoria")]
        [StringLength(70)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        //profilo
        [Required(ErrorMessage = "Codice fiscale obbligatorio")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "Il codice fiscale deve essere di 16 caratteri")]
        public string CodiceFiscale { get; set; } = string.Empty;

        [Required(ErrorMessage = "Data di nascita obbligatoria")]
        public DateOnly DataDiNascita { get; set; }
    }
}
