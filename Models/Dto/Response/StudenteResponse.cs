namespace Scuola.Models.Dto.Response
{
    public class StudenteResponse
    {
        //studente
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cognome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        //profilo
        public Guid ProfiloId { get; set; }
        public string CodiceFiscale { get; set; } = string.Empty;
        public DateOnly DataDiNascita { get; set; }
    }
}