using Microsoft.EntityFrameworkCore;
using Scuola.Models.Entity;
using Scuola.Models.Dto.Request;
using Scuola.Models.Dto.Response;
using Scuola.Models.Mappings;

namespace Scuola.Services
{
    public class StudenteService : ServiceBase
    {
        public StudenteService(ApplicationDbContext context) : base(context)
        {
        }

        //lista studenti con profilo
        public async Task<List<StudenteResponse>> GetStudentiAsync()
        {
            try
            {
                var studenti = await _context.Studenti
                    .Include(s => s.Profilo)
                    .AsNoTracking()
                    .ToListAsync();

                return StudenteMapper.Convert(studenti);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<StudenteResponse>();
            }
        }

        //studente by id con profilo
        public async Task<StudenteResponse?> GetStudenteAsync(Guid id)
        {
            try
            {
                var studente = await _context.Studenti
                    .Include(s => s.Profilo)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(s => s.Id == id);

                if (studente is null)
                {
                    return null;
                }

                return StudenteMapper.Convert(studente);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        //creare studente con profilo
        public async Task<StudenteResponse?> CreateStudenteAsync(CreateStudenteRequest request)
        {
            try
            {
                var studente = new Studente
                {
                    Id = Guid.NewGuid(),
                    Nome = request.Nome,
                    Cognome = request.Cognome,
                    Email = request.Email
                };

                var profilo = new StudenteProfilo
                {
                    Id = Guid.NewGuid(),
                    Nome = request.Nome,
                    Cognome = request.Cognome,
                    CodiceFiscale = request.CodiceFiscale,
                    DataDiNascita = request.DataDiNascita,
                    StudenteId = studente.Id
                };

                _context.Studenti.Add(studente);
                _context.Profili.Add(profilo);

                if (await SaveAsync())
                {
                    studente.Profilo = profilo;
                    return StudenteMapper.Convert(studente);
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        //update studente profilo
        public async Task<StudenteResponse?> UpdateStudenteAsync(UpdateStudenteRequest request)
        {
            try
            {
                var studente = await _context.Studenti
                    .Include(s => s.Profilo)
                    .FirstOrDefaultAsync(s => s.Id == request.Id);

                if (studente is null)
                {
                    return null;
                }

                if (!string.IsNullOrEmpty(request.Nome))
                    studente.Nome = request.Nome;
                if (!string.IsNullOrEmpty(request.Cognome))
                    studente.Cognome = request.Cognome;
                if (!string.IsNullOrEmpty(request.Email))
                    studente.Email = request.Email;

                if (studente.Profilo != null)
                {
                    if (!string.IsNullOrEmpty(request.Nome))
                        studente.Profilo.Nome = request.Nome;
                    if (!string.IsNullOrEmpty(request.Cognome))
                        studente.Profilo.Cognome = request.Cognome;
                    if (!string.IsNullOrEmpty(request.CodiceFiscale))
                        studente.Profilo.CodiceFiscale = request.CodiceFiscale;
                    if (request.DataDiNascita.HasValue)
                        studente.Profilo.DataDiNascita = request.DataDiNascita.Value;
                }

                if (await SaveAsync())
                {
                    return StudenteMapper.Convert(studente);
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        //elimina studente
        public async Task<bool> DeleteStudenteAsync(Guid id)
        {
            try
            {
                var studente = await _context.Studenti.FindAsync(id);
                if (studente is null)
                    return false;

                _context.Studenti.Remove(studente);
                return await SaveAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}