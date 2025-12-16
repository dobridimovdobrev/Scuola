using Scuola.Models.Entity;
using Scuola.Models.Dto.Response;

namespace Scuola.Models.Mappings
{
    public static class StudenteMapper
    {
        //studente
        public static StudenteResponse Convert(Studente studente)
        {
            return new StudenteResponse
            {
                Id = studente.Id,
                Nome = studente.Nome,
                Cognome = studente.Cognome,
                Email = studente.Email,
                ProfiloId = studente.Profilo?.Id ?? Guid.Empty,
                CodiceFiscale = studente.Profilo?.CodiceFiscale ?? string.Empty,
                DataDiNascita = studente.Profilo?.DataDiNascita ?? DateOnly.MinValue
            };
        }

        //lista studenti
        public static List<StudenteResponse> Convert(List<Studente> studenti)
        {
            List<StudenteResponse> result = new List<StudenteResponse>();
            foreach (Studente studente in studenti)
            {
                result.Add(Convert(studente));
            }
            return result;
        }
    }
}