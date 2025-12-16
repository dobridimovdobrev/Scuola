using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scuola.Models.Entity
{
    public class StudenteProfilo
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Nome obbligatorio")]
        [StringLength(50)]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Cognome obbligatorio")]
        [StringLength(50)]
        public string Cognome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Codice fiscale obbligatorio")]
        [StringLength(16)]
        public string CodiceFiscale { get; set; } = string.Empty;

        [Required(ErrorMessage = "Data di nascita obbligatoria")]
        public DateOnly DataDiNascita { get; set; }

        //relazione uno a uno
        public Studente? Studente { get; set; }

    }
}
