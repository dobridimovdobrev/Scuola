using System.ComponentModel.DataAnnotations;

namespace Scuola.Models.Entity
{
    public class Studente
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Nome obbligatorio")]
        [StringLength(50)]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Cognome obbligatorio")]
        [StringLength(50)]
        public string Cognome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email obbligatorio")]
        [StringLength(70)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}
