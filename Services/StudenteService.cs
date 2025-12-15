using Microsoft.EntityFrameworkCore;
using Scuola.Models.Entity;

namespace Scuola.Services
{
    public class StudenteService : ServiceBase
    {
        public StudenteService(ApplicationDbContext context) : base(context)
        {
        }

        //lista studenti
        public async Task<List<Studente>> GetStudentiAsync()
        {

            try
            {
                return await _context.Studenti.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Studente>();
            }
        }

        // get studente by id
        public async Task<Studente?> GetStudenteAsync(Guid id)
        {
            try
            {
                return await _context.Studenti.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


        // creare studente
        public async Task<bool> CreateStudentAsync(Studente studente)
        {
            try
            {
                _context.Studenti.Add(studente);
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
